﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class azdasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "GridViewLayout",
                value: "<XtraSerializer version=\"1.0\" application=\"View\">\r\n	<property name=\"#LayoutVersion\" />\r\n	<property name=\"#LayoutScaleFactor\">@1,Width=1@1,Height=1</property>\r\n	<property name=\"Appearance\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"Row\" iskey=\"true\" value=\"Row\">\r\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\r\n				<property name=\"UseFont\">true</property>\r\n			</property>\r\n			<property name=\"Font\">Tahoma, 12pt</property>\r\n		</property>\r\n		<property name=\"FooterPanel\" iskey=\"true\" value=\"FooterPanel\">\r\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\r\n				<property name=\"UseFont\">true</property>\r\n			</property>\r\n			<property name=\"Font\">Tahoma, 12pt</property>\r\n		</property>\r\n	</property>\r\n	<property name=\"OptionsBehavior\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"Editable\">false</property>\r\n		<property name=\"ReadOnly\">true</property>\r\n	</property>\r\n	<property name=\"OptionsView\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"ColumnHeaderAutoHeight\">True</property>\r\n		<property name=\"ShowAutoFilterRow\">true</property>\r\n		<property name=\"ShowGroupPanel\">false</property>\r\n		<property name=\"ShowIndicator\">false</property>\r\n	</property>\r\n	<property name=\"FixedLineWidth\">2</property>\r\n	<property name=\"IndicatorWidth\">-1</property>\r\n	<property name=\"ColumnPanelRowHeight\">-1</property>\r\n	<property name=\"RowSeparatorHeight\">0</property>\r\n	<property name=\"FooterPanelHeight\">-1</property>\r\n	<property name=\"HorzScrollVisibility\">Auto</property>\r\n	<property name=\"VertScrollVisibility\">Auto</property>\r\n	<property name=\"RowHeight\">-1</property>\r\n	<property name=\"GroupRowHeight\">-1</property>\r\n	<property name=\"GroupFormat\">{0}: [#image]{1} {2}</property>\r\n	<property name=\"ChildGridLevelName\" />\r\n	<property name=\"VertScrollTipFieldName\" />\r\n	<property name=\"PreviewFieldName\" />\r\n	<property name=\"GroupPanelText\" />\r\n	<property name=\"NewItemRowText\" />\r\n	<property name=\"LevelIndent\">-1</property>\r\n	<property name=\"PreviewIndent\">-1</property>\r\n	<property name=\"PreviewLineCount\">-1</property>\r\n	<property name=\"ScrollStyle\">LiveVertScroll, LiveHorzScroll</property>\r\n	<property name=\"FocusRectStyle\">CellFocus</property>\r\n	<property name=\"HorzScrollStep\">0</property>\r\n	<property name=\"ActiveFilterEnabled\">true</property>\r\n	<property name=\"ViewCaptionHeight\">-1</property>\r\n	<property name=\"Columns\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"ViewCaption\" />\r\n	<property name=\"BorderStyle\">Default</property>\r\n	<property name=\"SynchronizeClones\">true</property>\r\n	<property name=\"DetailTabHeaderLocation\">Top</property>\r\n	<property name=\"Name\">gridView1</property>\r\n	<property name=\"DetailHeight\">350</property>\r\n	<property name=\"Tag\" isnull=\"true\" />\r\n	<property name=\"GroupSummary\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"ActiveFilterString\" />\r\n	<property name=\"FormatRules\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"FormatConditions\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"GroupSummarySortInfoState\" />\r\n	<property name=\"FindFilterText\" />\r\n	<property name=\"FindPanelVisible\">true</property>\r\n</XtraSerializer>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "GridViewLayout",
                value: "<XtraSerializer version=\"1.0\" application=\"View\">\r\n	<property name=\"#LayoutVersion\" />\r\n	<property name=\"#LayoutScaleFactor\">@1,Width=1@1,Height=1</property>\r\n	<property name=\"Appearance\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"Row\" iskey=\"true\" value=\"Row\">\r\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\r\n				<property name=\"UseFont\">true</property>\r\n			</property>\r\n			<property name=\"Font\">Tahoma, 12pt</property>\r\n		</property>\r\n		<property name=\"FooterPanel\" iskey=\"true\" value=\"FooterPanel\">\r\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\r\n				<property name=\"UseFont\">true</property>\r\n			</property>\r\n			<property name=\"Font\">Tahoma, 12pt</property>\r\n		</property>\r\n	</property>\r\n	<property name=\"OptionsBehavior\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"Editable\">false</property>\r\n		<property name=\"ReadOnly\">true</property>\r\n	</property>\r\n	<property name=\"OptionsView\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"ColumnHeaderAutoHeight\">True</property>\r\n		<property name=\"ShowGroupPanel\">false</property>\r\n		<property name=\"ShowIndicator\">false</property>\r\n	</property>\r\n	<property name=\"FixedLineWidth\">2</property>\r\n	<property name=\"IndicatorWidth\">-1</property>\r\n	<property name=\"ColumnPanelRowHeight\">-1</property>\r\n	<property name=\"RowSeparatorHeight\">0</property>\r\n	<property name=\"FooterPanelHeight\">-1</property>\r\n	<property name=\"HorzScrollVisibility\">Auto</property>\r\n	<property name=\"VertScrollVisibility\">Auto</property>\r\n	<property name=\"RowHeight\">-1</property>\r\n	<property name=\"GroupRowHeight\">-1</property>\r\n	<property name=\"GroupFormat\">{0}: [#image]{1} {2}</property>\r\n	<property name=\"ChildGridLevelName\" />\r\n	<property name=\"VertScrollTipFieldName\" />\r\n	<property name=\"PreviewFieldName\" />\r\n	<property name=\"GroupPanelText\" />\r\n	<property name=\"NewItemRowText\" />\r\n	<property name=\"LevelIndent\">-1</property>\r\n	<property name=\"PreviewIndent\">-1</property>\r\n	<property name=\"PreviewLineCount\">-1</property>\r\n	<property name=\"ScrollStyle\">LiveVertScroll, LiveHorzScroll</property>\r\n	<property name=\"FocusRectStyle\">CellFocus</property>\r\n	<property name=\"HorzScrollStep\">0</property>\r\n	<property name=\"ActiveFilterEnabled\">true</property>\r\n	<property name=\"ViewCaptionHeight\">-1</property>\r\n	<property name=\"Columns\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"ViewCaption\" />\r\n	<property name=\"BorderStyle\">Default</property>\r\n	<property name=\"SynchronizeClones\">true</property>\r\n	<property name=\"DetailTabHeaderLocation\">Top</property>\r\n	<property name=\"Name\">gridView1</property>\r\n	<property name=\"DetailHeight\">350</property>\r\n	<property name=\"Tag\" isnull=\"true\" />\r\n	<property name=\"GroupSummary\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"ActiveFilterString\" />\r\n	<property name=\"FormatRules\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"FormatConditions\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"GroupSummarySortInfoState\" />\r\n	<property name=\"FindFilterText\" />\r\n	<property name=\"FindPanelVisible\">true</property>\r\n</XtraSerializer>");
        }
    }
}
