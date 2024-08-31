using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class View_ProductHierarchies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

                    

					CREATE OR ALTER VIEW ProductHierarchies AS
					SELECT p.ProductCode
						, Level0 = COALESCE(lv0.HierarchyCode, lv1.HierarchyCode, lv2.HierarchyCode, lv3.HierarchyCode)
						, Level1 = CASE 
										WHEN lv0.HierarchyCode IS NOT NULL THEN lv1.HierarchyCode
										WHEN lv1.HierarchyCode IS NOT NULL THEN lv2.HierarchyCode
										WHEN lv2.HierarchyCode IS NOT NULL THEN lv3.HierarchyCode
										ELSE NULL
									END
						, Level2 = CASE 
										WHEN lv0.HierarchyCode IS NOT NULL THEN lv2.HierarchyCode
										WHEN lv1.HierarchyCode IS NOT NULL THEN lv3.HierarchyCode
										ELSE NULL
									END 
						, Level3 = CASE 
										WHEN lv0.HierarchyCode IS NOT NULL THEN lv3.HierarchyCode
										ELSE NULL
									END  
					FROM
						dcProducts p
					LEFT JOIN DcHierarchies lv3 ON p.HierarchyCode = lv3.HierarchyCode
					LEFT JOIN DcHierarchies lv2 ON lv3.HierarchyParentCode = lv2.HierarchyCode
					LEFT JOIN DcHierarchies lv1 ON lv2.HierarchyParentCode = lv1.HierarchyCode
					LEFT JOIN DcHierarchies lv0 ON lv1.HierarchyParentCode = lv0.HierarchyCode;



                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
