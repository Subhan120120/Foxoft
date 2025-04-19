using DevExpress.XtraEditors;
using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Foxoft
{
    public class AdoMethods
    {

        private string subConnString = Properties.Settings.Default.SubConnString;


        private SqlParameter[] paramArray = Array.Empty<SqlParameter>();

        public int SqlExec(string query)
        {
            using SqlConnection con = new(subConnString);
            using SqlCommand cmd = new(query, con);
            con.Open();

            int result = cmd.ExecuteNonQuery();

            //if (result < 0)
            //    XtraMessageBox.Show("Data Əlavə edilməsində xəta baş verdi!");
            return result;
        }

        public int SqlExec(string query, SqlParameter[] sqlParameters)
        {
            using SqlConnection con = new(subConnString);
            using SqlCommand cmd = new(query, con);


            cmd.Parameters.AddRange(sqlParameters);
            con.Open();

            int result = cmd.ExecuteNonQuery();

            //if (result < 0)
            //    XtraMessageBox.Show("Data Əlavə edilməsində xəta baş verdi!");
            return result;
        }

        public DataTable SqlGetDt(string query)
        {
            using SqlConnection con = new(subConnString);
            con.Open();

            using SqlCommand cmd = new(query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new();
            dt.Load(dr);

            ReflectionExt.SetCaptionName(dt);

            return dt;
        }

        public DataTable SqlGetDt(string query, SqlParameter[] sqlParameters)
        {
            using SqlConnection con = new(subConnString);
            using SqlDataAdapter da = new(query, con);

            da.SelectCommand.Parameters.AddRange(sqlParameters);
            DataTable dt = new();
            da.Fill(dt);

            if (dt.Columns.Contains("RowNum"))
                dt.Columns.Remove("RowNum");

            ReflectionExt.SetCaptionName(dt);

            return dt;
        }

        public string DatabaseAVGFragmentationPercent()
        {
            string queryGetFragAvg = @"
                    Select COALESCE(ROUND(AVG(avg_fragmentation_in_percent), 2), 0) as [FragAvg] From (
                    
                    SELECT 
                        dbschemas.name AS SchemaName,
                        dbtables.name AS TableName,
                        dbindexes.name AS IndexName,
                        indexstats.avg_fragmentation_in_percent,
                        indexstats.page_count
                    FROM 
                        sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, 'LIMITED') AS indexstats
                    INNER JOIN 
                        sys.tables dbtables ON indexstats.object_id = dbtables.object_id
                    INNER JOIN 
                        sys.schemas dbschemas ON dbtables.schema_id = dbschemas.schema_id
                    INNER JOIN 
                        sys.indexes AS dbindexes ON indexstats.object_id = dbindexes.object_id 
                        AND indexstats.index_id = dbindexes.index_id
                    WHERE 
                        dbindexes.type > 0  -- 0 = Heap, 1 = Clustered, 2 = Nonclustered
                        AND indexstats.page_count > 0 -- Ignore small tables
                     AND indexstats.avg_fragmentation_in_percent > 0
                    
                    --ORDER BY 
                    --    indexstats.avg_fragmentation_in_percent DESC
                    ) as ortalama";


            DataTable? asda = SqlGetDt(queryGetFragAvg);
            return asda.Rows[0][0].ToString();
        }

        public void RebuldOrReorganizeDatabase()
        {
            string queryRebuldOrReorganize = @"
                DECLARE @SchemaName NVARCHAR(MAX);
                DECLARE @TableName NVARCHAR(MAX);
                DECLARE @IndexName NVARCHAR(MAX);
                DECLARE @Fragmentation FLOAT;
                DECLARE @SQL NVARCHAR(MAX);
                
                DECLARE IndexCursor CURSOR FOR
                SELECT 
                    dbschemas.name AS SchemaName,
                    dbtables.name AS TableName,
                    dbindexes.name AS IndexName,
                    indexstats.avg_fragmentation_in_percent
                FROM 
                    sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, 'LIMITED') AS indexstats
                INNER JOIN 
                    sys.tables dbtables ON indexstats.object_id = dbtables.object_id
                INNER JOIN 
                    sys.schemas dbschemas ON dbtables.schema_id = dbschemas.schema_id
                INNER JOIN 
                    sys.indexes AS dbindexes ON indexstats.object_id = dbindexes.object_id 
                    AND indexstats.index_id = dbindexes.index_id
                WHERE 
                    dbindexes.type > 0  -- Exclude heaps
                    AND indexstats.page_count > 0;  -- Ignore small tables
                
                OPEN IndexCursor;
                
                FETCH NEXT FROM IndexCursor INTO @SchemaName, @TableName, @IndexName, @Fragmentation;
                
                WHILE @@FETCH_STATUS = 0
                BEGIN
                    IF @Fragmentation > 0
					BEGIN
						SET @SQL = 'ALTER INDEX [' + @IndexName + '] ON [' + @SchemaName + '].[' + @TableName + '] REBUILD PARTITION = ALL WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ';
						PRINT @SQL;  -- Optional for logging
						EXEC sp_executesql @SQL;	
					END
                
                    FETCH NEXT FROM IndexCursor INTO @SchemaName, @TableName, @IndexName, @Fragmentation;
                END
                
                CLOSE IndexCursor;
                DEALLOCATE IndexCursor;
                ";

            SqlExec(queryRebuldOrReorganize);
        }
    }
}