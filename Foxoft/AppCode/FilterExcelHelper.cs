using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft.AppCode
{
    public static class FilterExcelHelper
    {
        public class FilterRowItem
        {
            public int Id { get; set; }
            public int ParentId { get; set; }
            public string NodeType { get; set; } = "Condition"; // "Group" or "Condition"
            public string Logic { get; set; } = "And"; // "And", "Or", "NotAnd", "NotOr"
            public string Field { get; set; } = "";
            public string Caption { get; set; } = "";
            public string Operator { get; set; } = "";
            public object? Value { get; set; }
            public object? Value2 { get; set; }
            public List<string> ValuesList { get; set; } = new();
        }

        #region Entire Filter Export / Import (Bütün Filter)

        public static void ExportEntireFilterToExcel(FilterControl filterControl, IWin32Window? owner = null)
        {
            if (filterControl == null)
                return;

            GroupNode? rootNode = filterControl.Model?.RootNode as GroupNode;
            if (rootNode == null || rootNode.SubNodes.Count == 0)
            {
                XtraMessageBox.Show(
                    owner,
                    Properties.Resources.Common_Filter_NoDataToExport,
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using var sfd = new XtraSaveFileDialog
            {
                Filter = Properties.Resources.Common_File_ExcelFilter,
                Title = Properties.Resources.Common_Filter_ExportEntireFilter,
                FileName = $"Filter_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                DefaultExt = "xlsx"
            };

            if (sfd.ShowDialog(owner) != DialogResult.OK)
                return;

            try
            {
                SaveFilterToExcelFile(filterControl, sfd.FileName);

                if (XtraMessageBox.Show(
                        owner,
                        Properties.Resources.Common_OpenQuestion,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
                {
                    using var p = new Process
                    {
                        StartInfo = new ProcessStartInfo(sfd.FileName) { UseShellExecute = true }
                    };
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    owner,
                    string.Format(Properties.Resources.Common_Filter_ImportError, ex.Message),
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        [Obsolete("Use ExportEntireFilterToExcel instead.")]
        public static void ExportFilterToExcel(FilterControl filterControl, IWin32Window? owner = null)
            => ExportEntireFilterToExcel(filterControl, owner);

        public static void SaveFilterToExcelFile(FilterControl filterControl, string filePath)
        {
            GroupNode? rootNode = filterControl.Model?.RootNode as GroupNode;
            if (rootNode == null || rootNode.SubNodes.Count == 0)
                throw new InvalidOperationException("Filter is empty.");

            List<FilterRowItem> rowItems = new();
            int currentId = 1;
            TraverseNodeForExport(rootNode, 0, ref currentId, rowItems, filterControl.FilterColumns);

            using var workbook = new Workbook();
            var filterSheet = workbook.Worksheets[0];
            filterSheet.Name = "Filter";

            string[] headers = { "Id", "ParentId", "NodeType", "Logic", "Field", "Caption", "Operator", "Value", "Value2" };
            for (int c = 0; c < headers.Length; c++)
            {
                filterSheet.Cells[0, c].Value = headers[c];
            }

            int rIndex = 1;
            bool hasDetailedValues = false;
            foreach (var item in rowItems)
            {
                filterSheet.Cells[rIndex, 0].Value = item.Id;
                filterSheet.Cells[rIndex, 1].Value = item.ParentId;
                filterSheet.Cells[rIndex, 2].Value = item.NodeType;
                filterSheet.Cells[rIndex, 3].Value = item.Logic;
                filterSheet.Cells[rIndex, 4].Value = item.Field;
                filterSheet.Cells[rIndex, 5].Value = item.Caption;
                filterSheet.Cells[rIndex, 6].Value = item.Operator;

                if (item.Value != null)
                    filterSheet.Cells[rIndex, 7].SetValue(item.Value);
                if (item.Value2 != null)
                    filterSheet.Cells[rIndex, 8].SetValue(item.Value2);

                if (item.ValuesList.Count > 0)
                    hasDetailedValues = true;

                rIndex++;
            }

            var headerRange = filterSheet.Range.FromLTRB(0, 0, headers.Length - 1, 0);
            headerRange.Font.Bold = true;
            headerRange.FillColor = Color.FromArgb(235, 241, 250);
            filterSheet.Columns.AutoFit(0, headers.Length - 1);

            if (hasDetailedValues)
            {
                var valuesSheet = workbook.Worksheets.Add("Values");
                valuesSheet.Cells[0, 0].Value = "NodeId";
                valuesSheet.Cells[0, 1].Value = "Field";
                valuesSheet.Cells[0, 2].Value = "Value";

                var vHeader = valuesSheet.Range.FromLTRB(0, 0, 2, 0);
                vHeader.Font.Bold = true;
                vHeader.FillColor = Color.FromArgb(235, 241, 250);

                int vrIndex = 1;
                foreach (var item in rowItems.Where(x => x.ValuesList.Count > 0))
                {
                    foreach (var val in item.ValuesList)
                    {
                        valuesSheet.Cells[vrIndex, 0].Value = item.Id;
                        valuesSheet.Cells[vrIndex, 1].Value = item.Field;
                        valuesSheet.Cells[vrIndex, 2].Value = val;
                        vrIndex++;
                    }
                }
                valuesSheet.Columns.AutoFit(0, 2);
            }

            var criteriaSheet = workbook.Worksheets.Add("Criteria");
            criteriaSheet.Cells[0, 0].Value = "FilterCriteria";
            criteriaSheet.Cells[1, 0].Value = filterControl.FilterCriteria?.ToString() ?? filterControl.FilterString ?? "";
            criteriaSheet.Range.FromLTRB(0, 0, 0, 0).Font.Bold = true;
            criteriaSheet.Columns.AutoFit(0, 0);

            workbook.SaveDocument(filePath, DocumentFormat.Xlsx);
        }

        private static void TraverseNodeForExport(
            Node node,
            int parentId,
            ref int currentId,
            List<FilterRowItem> rowItems,
            FilterColumnCollection? columns)
        {
            int myId = currentId++;

            if (node is GroupNode gn)
            {
                var groupItem = new FilterRowItem
                {
                    Id = myId,
                    ParentId = parentId,
                    NodeType = "Group",
                    Logic = gn.NodeType.ToString()
                };
                rowItems.Add(groupItem);

                foreach (Node subNode in gn.SubNodes)
                {
                    TraverseNodeForExport(subNode, myId, ref currentId, rowItems, columns);
                }
            }
            else if (node is ClauseNode cn)
            {
                string fieldName = cn.FirstOperand?.PropertyName ?? "";
                string caption = columns?[fieldName]?.ColumnCaption ?? fieldName;
                string op = cn.Operation.ToString();

                var clauseItem = new FilterRowItem
                {
                    Id = myId,
                    ParentId = parentId,
                    NodeType = "Condition",
                    Field = fieldName,
                    Caption = caption,
                    Operator = op
                };

                if (cn.Operation == ClauseType.AnyOf || cn.Operation == ClauseType.NoneOf)
                {
                    foreach (var operand in cn.AdditionalOperands)
                    {
                        object? val = GetOperandRawValue(operand);
                        if (val != null)
                        {
                            clauseItem.ValuesList.Add(val.ToString() ?? "");
                        }
                    }
                    clauseItem.Value = string.Join("; ", clauseItem.ValuesList);
                }
                else if (cn.Operation == ClauseType.Between || cn.Operation == ClauseType.NotBetween)
                {
                    if (cn.AdditionalOperands.Count > 0)
                        clauseItem.Value = GetOperandRawValue(cn.AdditionalOperands[0]);
                    if (cn.AdditionalOperands.Count > 1)
                        clauseItem.Value2 = GetOperandRawValue(cn.AdditionalOperands[1]);
                }
                else if (cn.AdditionalOperands.Count > 0)
                {
                    clauseItem.Value = GetOperandRawValue(cn.AdditionalOperands[0]);
                }

                rowItems.Add(clauseItem);
            }
        }

        public static object? GetOperandRawValue(CriteriaOperator? op)
        {
            if (op == null) return null;
            if (op is OperandValue ov) return ov.Value;
            if (op is ConstantValue cv) return cv.Value;
            if (op is OperandProperty opProp) return opProp.PropertyName;
            return op.ToString();
        }

        #endregion

        #region Import Entire Filter (Bütün Filter)

        public static bool ImportEntireFilterFromExcel(FilterControl filterControl, IWin32Window? owner = null)
        {
            if (filterControl == null)
                return false;

            using var ofd = new XtraOpenFileDialog
            {
                Filter = Properties.Resources.Common_Filter_ExcelDialogFilter,
                Title = Properties.Resources.Common_Filter_ImportEntireFilter
            };

            if (ofd.ShowDialog(owner) != DialogResult.OK)
                return false;

            try
            {
                CriteriaOperator? resultCriteria = LoadFilterFromExcelFile(ofd.FileName, filterControl.FilterColumns);

                if (!ReferenceEquals(resultCriteria, null))
                {
                    filterControl.FilterCriteria = resultCriteria;
                    filterControl.Refresh();

                    XtraMessageBox.Show(
                        owner,
                        Properties.Resources.Common_Filter_ImportSuccess,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return true;
                }
                else
                {
                    XtraMessageBox.Show(
                        owner,
                        Properties.Resources.Common_Filter_NoDataToExport,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    owner,
                    string.Format(Properties.Resources.Common_Filter_ImportError, ex.Message),
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        [Obsolete("Use ImportEntireFilterFromExcel instead.")]
        public static bool ImportFilterFromExcel(FilterControl filterControl, IWin32Window? owner = null)
            => ImportEntireFilterFromExcel(filterControl, owner);

        public static CriteriaOperator? LoadFilterFromExcelFile(string filePath, FilterColumnCollection? columns)
        {
            using var workbook = new Workbook();
            workbook.LoadDocument(filePath);

            if (workbook.Worksheets.Count == 0)
                return null;

            Dictionary<int, List<string>> valuesByNodeId = new();
            Dictionary<string, List<string>> valuesByField = new(StringComparer.OrdinalIgnoreCase);

            var valuesSheet = workbook.Worksheets["Values"];
            if (valuesSheet != null)
            {
                ReadValuesSheet(valuesSheet, valuesByNodeId, valuesByField);
            }

            var filterSheet = workbook.Worksheets["Filter"] ?? workbook.Worksheets[0];
            CriteriaOperator? resultCriteria = ParseSheetToCriteria(filterSheet, valuesByNodeId, valuesByField, columns);

            if (ReferenceEquals(resultCriteria, null))
            {
                var criteriaSheet = workbook.Worksheets["Criteria"];
                if (criteriaSheet != null && criteriaSheet.Rows.LastUsedIndex >= 1)
                {
                    string cText = criteriaSheet.Cells[1, 0].DisplayText;
                    if (!string.IsNullOrWhiteSpace(cText))
                    {
                        resultCriteria = CriteriaOperator.Parse(cText);
                    }
                }
            }

            return resultCriteria;
        }

        public static bool RunSelfTest(out string message)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"FilterTest_{Guid.NewGuid():N}.xlsx");
            try
            {
                var dt = new System.Data.DataTable();
                dt.Columns.Add("Barcode", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Columns.Add("Category", typeof(string));
                dt.Columns.Add("IsDisabled", typeof(bool));

                var fc = new FilterControl { SourceControl = dt };

                var originalCriteria = new GroupOperator(GroupOperatorType.And,
                    new InOperator("Barcode", new CriteriaOperator[] { new OperandValue("B01"), new OperandValue("B02"), new OperandValue("B03") }),
                    new BinaryOperator("Category", "Food", BinaryOperatorType.Equal),
                    new GroupOperator(GroupOperatorType.Or,
                        new BetweenOperator("Price", new OperandValue(10m), new OperandValue(50m)),
                        new BinaryOperator("IsDisabled", false, BinaryOperatorType.Equal)
                    )
                );

                fc.FilterCriteria = originalCriteria;

                SaveFilterToExcelFile(fc, tempFile);

                var loadedCriteria = LoadFilterFromExcelFile(tempFile, fc.FilterColumns);
                if (ReferenceEquals(loadedCriteria, null))
                {
                    message = "Loaded criteria is null!";
                    return false;
                }

                fc.FilterCriteria = loadedCriteria;
                string exportedFilterStr = fc.FilterString;

                fc.FilterCriteria = originalCriteria;
                string originalFilterStr = fc.FilterString;

                if (!string.Equals(exportedFilterStr, originalFilterStr, StringComparison.OrdinalIgnoreCase))
                {
                    message = $"Filter mismatch! Expected: {originalFilterStr}, Got: {exportedFilterStr}";
                    return false;
                }

                message = $"Self-test PASSED! Filter matched: {exportedFilterStr}";
                return true;
            }
            catch (Exception ex)
            {
                message = "Exception during self-test: " + ex;
                return false;
            }
            finally
            {
                try { if (File.Exists(tempFile)) File.Delete(tempFile); } catch { }
            }
        }

        private static void ReadValuesSheet(
            Worksheet sheet,
            Dictionary<int, List<string>> valuesByNodeId,
            Dictionary<string, List<string>> valuesByField)
        {
            int lastRow = sheet.Rows.LastUsedIndex;
            if (lastRow < 1) return;

            int nodeCol = -1;
            int fieldCol = -1;
            int valCol = -1;

            for (int c = 0; c <= sheet.Columns.LastUsedIndex; c++)
            {
                string header = sheet.Cells[0, c].DisplayText.Trim().ToLowerInvariant();
                if (header.Contains("node") || header.Contains("id"))
                    nodeCol = c;
                else if (header.Contains("field") || header.Contains("sütun") || header.Contains("sutun"))
                    fieldCol = c;
                else if (header.Contains("val") || header.Contains("dəyər") || header.Contains("deyer"))
                    valCol = c;
            }

            if (valCol == -1) valCol = sheet.Columns.LastUsedIndex;

            for (int r = 1; r <= lastRow; r++)
            {
                string val = sheet.Cells[r, valCol].DisplayText.Trim();
                if (string.IsNullOrWhiteSpace(val)) continue;

                if (nodeCol != -1 && int.TryParse(sheet.Cells[r, nodeCol].DisplayText.Trim(), out int nId))
                {
                    if (!valuesByNodeId.TryGetValue(nId, out var list))
                    {
                        list = new List<string>();
                        valuesByNodeId[nId] = list;
                    }
                    list.Add(val);
                }

                if (fieldCol != -1)
                {
                    string fld = sheet.Cells[r, fieldCol].DisplayText.Trim();
                    if (!string.IsNullOrWhiteSpace(fld))
                    {
                        if (!valuesByField.TryGetValue(fld, out var fList))
                        {
                            fList = new List<string>();
                            valuesByField[fld] = fList;
                        }
                        fList.Add(val);
                    }
                }
            }
        }

        private static CriteriaOperator? ParseSheetToCriteria(
            Worksheet sheet,
            Dictionary<int, List<string>> valuesByNodeId,
            Dictionary<string, List<string>> valuesByField,
            FilterColumnCollection? columns)
        {
            int lastRow = sheet.Rows.LastUsedIndex;
            int lastCol = sheet.Columns.LastUsedIndex;
            if (lastRow < 0) return null;

            int idCol = -1;
            int parentIdCol = -1;
            int nodeTypeCol = -1;
            int logicCol = -1;
            int fieldCol = -1;
            int captionCol = -1;
            int opCol = -1;
            int valCol = -1;
            int val2Col = -1;

            for (int c = 0; c <= lastCol; c++)
            {
                string h = sheet.Cells[0, c].DisplayText.Trim().ToLowerInvariant();
                if (h is "id" or "nömrə" or "nomre" or "no") idCol = c;
                else if (h is "parentid" or "valideynid" or "qrupid") parentIdCol = c;
                else if (h is "nodetype" or "tip" or "növ" or "nov") nodeTypeCol = c;
                else if (h is "logic" or "qrup" or "məntiq" or "mentiq" or "group") logicCol = c;
                else if (h is "field" or "fieldname" or "sütun" or "sutun" or "sahə" or "sahe" or "column") fieldCol = c;
                else if (h is "caption" or "başlıq" or "basliq") captionCol = c;
                else if (h is "operator" or "operation" or "şərt" or "sert" or "əməliyyat" or "emeliyyat") opCol = c;
                else if (h is "value" or "dəyər" or "deyer" or "qiymət" or "qiymet") valCol = c;
                else if (h is "value2" or "dəyər2" or "deyer2" or "valueto" or "son dəyər") val2Col = c;
            }

            // Case A: Single column of values (e.g. list of barcodes)
            if (opCol == -1 && fieldCol == -1)
            {
                string firstHeader = sheet.Cells[0, 0].DisplayText.Trim();
                var matchedCol = FindFilterColumn(columns, firstHeader);
                string targetField = matchedCol?.FieldName ?? firstHeader;

                int startR = matchedCol != null ? 1 : 0;
                List<string> singleColValues = new();
                for (int r = startR; r <= lastRow; r++)
                {
                    string v = sheet.Cells[r, 0].DisplayText.Trim();
                    if (!string.IsNullOrWhiteSpace(v))
                        singleColValues.Add(v);
                }

                if (singleColValues.Count > 0)
                {
                    Type t = matchedCol?.ColumnType ?? typeof(string);
                    var operands = singleColValues.Select(v => (CriteriaOperator)new OperandValue(ConvertValue(v, t)));
                    return new InOperator(new OperandProperty(targetField), operands);
                }
                return null;
            }

            // Case B: Table with conditions
            List<FilterRowItem> rows = new();
            int autoId = 1;

            for (int r = 1; r <= lastRow; r++)
            {
                string fld = fieldCol != -1 ? sheet.Cells[r, fieldCol].DisplayText.Trim() : "";
                string op = opCol != -1 ? sheet.Cells[r, opCol].DisplayText.Trim() : "";
                string logic = logicCol != -1 ? sheet.Cells[r, logicCol].DisplayText.Trim() : "";
                string nType = nodeTypeCol != -1 ? sheet.Cells[r, nodeTypeCol].DisplayText.Trim() : "";
                string v1 = valCol != -1 ? sheet.Cells[r, valCol].DisplayText.Trim() : "";
                string v2 = val2Col != -1 ? sheet.Cells[r, val2Col].DisplayText.Trim() : "";

                int id = autoId++;
                if (idCol != -1 && int.TryParse(sheet.Cells[r, idCol].DisplayText.Trim(), out int parsedId))
                    id = parsedId;

                int parentId = 0;
                if (parentIdCol != -1 && int.TryParse(sheet.Cells[r, parentIdCol].DisplayText.Trim(), out int parsedPId))
                    parentId = parsedPId;

                if (string.IsNullOrWhiteSpace(nType))
                {
                    nType = !string.IsNullOrWhiteSpace(fld) ? "Condition" : "Group";
                }

                if (string.IsNullOrWhiteSpace(fld) && string.IsNullOrWhiteSpace(logic) && string.IsNullOrWhiteSpace(op))
                    continue;

                var rowItem = new FilterRowItem
                {
                    Id = id,
                    ParentId = parentId,
                    NodeType = nType,
                    Logic = string.IsNullOrWhiteSpace(logic) ? "And" : logic,
                    Field = fld,
                    Operator = op,
                    Value = v1,
                    Value2 = v2
                };

                // Check detailed values
                if (valuesByNodeId.TryGetValue(id, out var nList) && nList.Count > 0)
                {
                    rowItem.ValuesList = nList;
                }
                else if (!string.IsNullOrWhiteSpace(fld) && valuesByField.TryGetValue(fld, out var fList) && fList.Count > 0)
                {
                    rowItem.ValuesList = fList;
                }
                else if (!string.IsNullOrWhiteSpace(v1))
                {
                    var parsedClause = ParseClauseType(op);
                    if (parsedClause is ClauseType.AnyOf or ClauseType.NoneOf)
                    {
                        var split = v1.Split(new[] { ';', ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(s => s.Trim().Trim('\'', '"'))
                                      .Where(s => !string.IsNullOrEmpty(s))
                                      .ToList();
                        rowItem.ValuesList = split;
                    }
                }

                rows.Add(rowItem);
            }

            if (rows.Count == 0) return null;

            // Merge multiple AnyOf rows with same field and parent
            MergeAnyOfRows(rows);

            // If ParentId column was not present or all 0, and has no Group nodes:
            bool hasGroups = rows.Any(x => x.NodeType.Equals("Group", StringComparison.OrdinalIgnoreCase));
            if (!hasGroups && rows.All(x => x.ParentId == 0))
            {
                var condList = rows.Select(r => BuildConditionCriteria(r, columns)).Where(c => !ReferenceEquals(c, null)).ToList();
                if (condList.Count == 0) return null;
                if (condList.Count == 1) return condList[0];
                return new GroupOperator(GroupOperatorType.And, condList);
            }

            // Tree construction from ParentId
            int rootParentId = rows.Select(x => x.ParentId).Min();
            var rootRows = rows.Where(x => x.ParentId == rootParentId).ToList();

            if (rootRows.Count == 1 && rootRows[0].NodeType.Equals("Group", StringComparison.OrdinalIgnoreCase))
            {
                return BuildCriteriaForGroup(rootRows[0], rows, columns);
            }

            var rootChildren = new List<CriteriaOperator>();
            foreach (var r in rootRows)
            {
                if (r.NodeType.Equals("Group", StringComparison.OrdinalIgnoreCase))
                {
                    var groupOp = BuildCriteriaForGroup(r, rows, columns);
                    if (!ReferenceEquals(groupOp, null))
                        rootChildren.Add(groupOp);
                }
                else
                {
                    var condOp = BuildConditionCriteria(r, columns);
                    if (!ReferenceEquals(condOp, null))
                        rootChildren.Add(condOp);
                }
            }

            if (rootChildren.Count == 0) return null;
            if (rootChildren.Count == 1) return rootChildren[0];
            return new GroupOperator(GroupOperatorType.And, rootChildren);
        }

        private static void MergeAnyOfRows(List<FilterRowItem> rows)
        {
            var merged = new List<FilterRowItem>();
            foreach (var group in rows.GroupBy(r => new { r.ParentId, r.Field, Op = ParseClauseType(r.Operator) }))
            {
                if ((group.Key.Op == ClauseType.AnyOf || group.Key.Op == ClauseType.NoneOf) && group.Count() > 1)
                {
                    var first = group.First();
                    var allValues = new List<string>(first.ValuesList);
                    foreach (var other in group.Skip(1))
                    {
                        if (other.ValuesList.Count > 0)
                            allValues.AddRange(other.ValuesList);
                        else if (other.Value != null)
                            allValues.Add(other.Value.ToString() ?? "");
                    }
                    first.ValuesList = allValues.Distinct().ToList();
                    first.Value = string.Join("; ", first.ValuesList);
                    merged.Add(first);
                }
                else
                {
                    merged.AddRange(group);
                }
            }
            rows.Clear();
            rows.AddRange(merged.OrderBy(x => x.Id));
        }

        private static CriteriaOperator? BuildCriteriaForGroup(
            FilterRowItem groupRow,
            List<FilterRowItem> allRows,
            FilterColumnCollection? columns)
        {
            var children = allRows.Where(x => x.ParentId == groupRow.Id).ToList();
            var childOps = new List<CriteriaOperator>();

            foreach (var child in children)
            {
                if (child.NodeType.Equals("Group", StringComparison.OrdinalIgnoreCase))
                {
                    var sub = BuildCriteriaForGroup(child, allRows, columns);
                    if (!ReferenceEquals(sub, null))
                        childOps.Add(sub);
                }
                else
                {
                    var cond = BuildConditionCriteria(child, columns);
                    if (!ReferenceEquals(cond, null))
                        childOps.Add(cond);
                }
            }

            if (childOps.Count == 0) return null;

            GroupType gt = ParseGroupType(groupRow.Logic);
            return gt switch
            {
                GroupType.Or => new GroupOperator(GroupOperatorType.Or, childOps),
                GroupType.NotAnd => new UnaryOperator(UnaryOperatorType.Not, new GroupOperator(GroupOperatorType.And, childOps)),
                GroupType.NotOr => new UnaryOperator(UnaryOperatorType.Not, new GroupOperator(GroupOperatorType.Or, childOps)),
                _ => new GroupOperator(GroupOperatorType.And, childOps)
            };
        }

        private static CriteriaOperator? BuildConditionCriteria(FilterRowItem row, FilterColumnCollection? columns)
        {
            if (string.IsNullOrWhiteSpace(row.Field))
                return null;

            var col = FindFilterColumn(columns, row.Field);
            string fieldName = col?.FieldName ?? row.Field;
            Type targetType = col?.ColumnType ?? typeof(string);

            ClauseType op = ParseClauseType(row.Operator);
            string rawV1 = row.Value?.ToString() ?? "";
            string rawV2 = row.Value2?.ToString() ?? "";

            var prop = new OperandProperty(fieldName);

            switch (op)
            {
                case ClauseType.Equals:
                    return new BinaryOperator(prop, new OperandValue(ConvertValue(rawV1, targetType)), BinaryOperatorType.Equal);

                case ClauseType.DoesNotEqual:
                    return new BinaryOperator(prop, new OperandValue(ConvertValue(rawV1, targetType)), BinaryOperatorType.NotEqual);

                case ClauseType.Greater:
                    return new BinaryOperator(prop, new OperandValue(ConvertValue(rawV1, targetType)), BinaryOperatorType.Greater);

                case ClauseType.GreaterOrEqual:
                    return new BinaryOperator(prop, new OperandValue(ConvertValue(rawV1, targetType)), BinaryOperatorType.GreaterOrEqual);

                case ClauseType.Less:
                    return new BinaryOperator(prop, new OperandValue(ConvertValue(rawV1, targetType)), BinaryOperatorType.Less);

                case ClauseType.LessOrEqual:
                    return new BinaryOperator(prop, new OperandValue(ConvertValue(rawV1, targetType)), BinaryOperatorType.LessOrEqual);

                case ClauseType.Between:
                    return new BetweenOperator(prop, new OperandValue(ConvertValue(rawV1, targetType)), new OperandValue(ConvertValue(rawV2, targetType)));

                case ClauseType.NotBetween:
                    return new UnaryOperator(UnaryOperatorType.Not,
                        new BetweenOperator(prop, new OperandValue(ConvertValue(rawV1, targetType)), new OperandValue(ConvertValue(rawV2, targetType))));

                case ClauseType.Contains:
                    return new FunctionOperator(FunctionOperatorType.Contains, prop, new OperandValue(rawV1));

                case ClauseType.DoesNotContain:
                    return new UnaryOperator(UnaryOperatorType.Not,
                        new FunctionOperator(FunctionOperatorType.Contains, prop, new OperandValue(rawV1)));

                case ClauseType.BeginsWith:
                    return new FunctionOperator(FunctionOperatorType.StartsWith, prop, new OperandValue(rawV1));

                case ClauseType.EndsWith:
                    return new FunctionOperator(FunctionOperatorType.EndsWith, prop, new OperandValue(rawV1));

                case ClauseType.Like:
                    return new BinaryOperator(prop, new OperandValue(rawV1), BinaryOperatorType.Like);

                case ClauseType.NotLike:
                    return new UnaryOperator(UnaryOperatorType.Not,
                        new BinaryOperator(prop, new OperandValue(rawV1), BinaryOperatorType.Like));

                case ClauseType.IsNull:
                    return new UnaryOperator(UnaryOperatorType.IsNull, prop);

                case ClauseType.IsNotNull:
                    return new UnaryOperator(UnaryOperatorType.Not, new UnaryOperator(UnaryOperatorType.IsNull, prop));

                case ClauseType.IsNullOrEmpty:
                    return new FunctionOperator(FunctionOperatorType.IsNullOrEmpty, prop);

                case ClauseType.IsNotNullOrEmpty:
                    return new UnaryOperator(UnaryOperatorType.Not,
                        new FunctionOperator(FunctionOperatorType.IsNullOrEmpty, prop));

                case ClauseType.AnyOf:
                    {
                        var list = row.ValuesList.Count > 0
                            ? row.ValuesList
                            : (string.IsNullOrWhiteSpace(rawV1) ? new List<string>() : new List<string> { rawV1 });
                        var operands = list.Select(v => (CriteriaOperator)new OperandValue(ConvertValue(v, targetType)));
                        return new InOperator(prop, operands);
                    }

                case ClauseType.NoneOf:
                    {
                        var list = row.ValuesList.Count > 0
                            ? row.ValuesList
                            : (string.IsNullOrWhiteSpace(rawV1) ? new List<string>() : new List<string> { rawV1 });
                        var operands = list.Select(v => (CriteriaOperator)new OperandValue(ConvertValue(v, targetType)));
                        return new UnaryOperator(UnaryOperatorType.Not, new InOperator(prop, operands));
                    }

                default:
                    return new BinaryOperator(prop, new OperandValue(ConvertValue(rawV1, targetType)), BinaryOperatorType.Equal);
            }
        }

        #endregion

        #region ClauseNode Values Export/Import (Cari Şərt Dəyərləri)

        public static void ExportClauseNodeValuesToExcel(ClauseNode clauseNode, FilterControl filterControl, IWin32Window? owner = null)
        {
            if (clauseNode == null) return;

            var values = new List<string>();
            foreach (var op in clauseNode.AdditionalOperands)
            {
                object? val = GetOperandRawValue(op);
                if (val != null) values.Add(val.ToString() ?? "");
            }

            if (values.Count == 0)
            {
                XtraMessageBox.Show(
                    owner,
                    Properties.Resources.Common_Filter_NoDataToExport,
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string fieldName = clauseNode.FirstOperand?.PropertyName ?? "Filter";
            using var sfd = new XtraSaveFileDialog
            {
                Filter = Properties.Resources.Common_File_ExcelFilter,
                Title = Properties.Resources.Common_Filter_Node_ExportExcel,
                FileName = $"{fieldName}_Values_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                DefaultExt = "xlsx"
            };

            if (sfd.ShowDialog(owner) != DialogResult.OK)
                return;

            try
            {
                using var workbook = new Workbook();
                var sheet = workbook.Worksheets[0];
                sheet.Cells[0, 0].Value = fieldName;
                sheet.Range["A1"].Font.Bold = true;

                for (int i = 0; i < values.Count; i++)
                {
                    sheet.Cells[i + 1, 0].Value = values[i];
                }
                sheet.Columns.AutoFit(0, 0);

                workbook.SaveDocument(sfd.FileName, DocumentFormat.Xlsx);

                if (XtraMessageBox.Show(
                        owner,
                        Properties.Resources.Common_OpenQuestion,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
                {
                    using var p = new Process { StartInfo = new ProcessStartInfo(sfd.FileName) { UseShellExecute = true } };
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    owner,
                    string.Format(Properties.Resources.Common_Filter_ImportError, ex.Message),
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        [Obsolete("Use ExportClauseNodeValuesToExcel instead.")]
        public static void ExportClauseNodeToExcel(ClauseNode clauseNode, FilterControl filterControl, IWin32Window? owner = null)
            => ExportClauseNodeValuesToExcel(clauseNode, filterControl, owner);

        public static bool ImportClauseNodeValuesFromExcel(ClauseNode clauseNode, FilterControl filterControl, IWin32Window? owner = null)
        {
            if (clauseNode == null) return false;

            using var ofd = new XtraOpenFileDialog
            {
                Filter = Properties.Resources.Common_Filter_ExcelDialogFilter,
                Title = Properties.Resources.Common_Filter_Node_ImportExcel
            };

            if (ofd.ShowDialog(owner) != DialogResult.OK)
                return false;

            try
            {
                using var workbook = new Workbook();
                workbook.LoadDocument(ofd.FileName);
                if (workbook.Worksheets.Count == 0) return false;

                var sheet = workbook.Worksheets[0];
                int lastRow = sheet.Rows.LastUsedIndex;
                if (lastRow < 0) return false;

                int startRow = 0;
                string firstCell = sheet.Cells[0, 0].DisplayText.Trim();
                string fieldName = clauseNode.FirstOperand?.PropertyName ?? "";

                if (string.Equals(firstCell, fieldName, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(firstCell, "value", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(firstCell, "dəyər", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(firstCell, "deyer", StringComparison.OrdinalIgnoreCase))
                {
                    startRow = 1;
                }

                var newValues = new List<string>();
                for (int r = startRow; r <= lastRow; r++)
                {
                    string val = sheet.Cells[r, 0].DisplayText.Trim();
                    if (!string.IsNullOrWhiteSpace(val))
                    {
                        newValues.Add(val);
                    }
                }

                if (newValues.Count > 0)
                {
                    if (clauseNode.Operation is ClauseType.AnyOf or ClauseType.NoneOf)
                    {
                        foreach (var v in newValues)
                        {
                            clauseNode.AdditionalOperands.Add(v);
                        }
                    }
                    else if (clauseNode.Operation is ClauseType.Between or ClauseType.NotBetween)
                    {
                        clauseNode.AdditionalOperands.Clear();
                        clauseNode.AdditionalOperands.Add(newValues[0]);
                        if (newValues.Count > 1)
                            clauseNode.AdditionalOperands.Add(newValues[1]);
                    }
                    else
                    {
                        clauseNode.AdditionalOperands.Clear();
                        clauseNode.AdditionalOperands.Add(newValues[0]);
                    }

                    filterControl.Refresh();

                    XtraMessageBox.Show(
                        owner,
                        Properties.Resources.Common_Filter_Node_ImportSuccess,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    owner,
                    string.Format(Properties.Resources.Common_Filter_ImportError, ex.Message),
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return false;
        }

        [Obsolete("Use ImportClauseNodeValuesFromExcel instead.")]
        public static bool ImportClauseNodeFromExcel(ClauseNode clauseNode, FilterControl filterControl, IWin32Window? owner = null)
            => ImportClauseNodeValuesFromExcel(clauseNode, filterControl, owner);

        #endregion

        #region Helpers

        public static FilterColumn? FindFilterColumn(FilterColumnCollection? columns, string fieldOrCaption)
        {
            if (columns == null || string.IsNullOrWhiteSpace(fieldOrCaption))
                return null;

            string target = fieldOrCaption.Trim();

            var col = columns[target];
            if (col != null) return col;

            foreach (FilterColumn c in columns)
            {
                if (string.Equals(c.FieldName, target, StringComparison.OrdinalIgnoreCase))
                    return c;
            }

            foreach (FilterColumn c in columns)
            {
                if (string.Equals(c.ColumnCaption, target, StringComparison.OrdinalIgnoreCase))
                    return c;
            }

            return null;
        }

        public static ClauseType ParseClauseType(string opStr)
        {
            if (string.IsNullOrWhiteSpace(opStr))
                return ClauseType.Equals;

            string s = opStr.Trim().ToLowerInvariant();
            return s switch
            {
                "=" or "==" or "equals" or "equal" or "bərabərdir" or "beraberdir" => ClauseType.Equals,
                "!=" or "<>" or "doesnotequal" or "notequal" or "bərabər deyil" or "beraber deyil" => ClauseType.DoesNotEqual,
                ">" or "greater" or "greaterthan" or "böyükdür" or "boyukdur" => ClauseType.Greater,
                ">=" or "greaterorequal" or "greaterthanorequal" or "böyük bərabərdir" or "boyuk beraberdir" => ClauseType.GreaterOrEqual,
                "<" or "less" or "lessthan" or "kiçikdir" or "kicikdir" => ClauseType.Less,
                "<=" or "lessorequal" or "lessthanorequal" or "kiçik bərabərdir" or "kicik beraberdir" => ClauseType.LessOrEqual,
                "between" or "inrange" or "arasında" or "arasinda" => ClauseType.Between,
                "notbetween" or "notinrange" or "arasında deyil" or "arasinda deyil" => ClauseType.NotBetween,
                "contains" or "tərkibində var" or "terkibinde var" or "ehtiva edir" => ClauseType.Contains,
                "doesnotcontain" or "tərkibində yoxdur" or "terkibinde yoxdur" => ClauseType.DoesNotContain,
                "beginswith" or "startswith" or "ilə başlayır" or "ile baslayir" => ClauseType.BeginsWith,
                "endswith" or "ilə bitir" or "ile bitir" => ClauseType.EndsWith,
                "like" or "oxşardır" or "oxsardir" => ClauseType.Like,
                "notlike" or "oxşar deyil" or "oxsar deyil" => ClauseType.NotLike,
                "anyof" or "in" or "isanyof" or "daxildir" or "siyahıdadır" or "siyahidadir" => ClauseType.AnyOf,
                "noneof" or "notin" or "isnoneof" or "daxil deyil" or "siyahıda deyil" => ClauseType.NoneOf,
                "isnull" or "boşdur" or "bosdur" => ClauseType.IsNull,
                "isnotnull" or "boş deyil" or "bos deyil" => ClauseType.IsNotNull,
                "isnullorempty" => ClauseType.IsNullOrEmpty,
                "isnotnullorempty" => ClauseType.IsNotNullOrEmpty,
                _ => Enum.TryParse<ClauseType>(opStr, true, out var ct) ? ct : ClauseType.Equals
            };
        }

        public static GroupType ParseGroupType(string logicStr)
        {
            if (string.IsNullOrWhiteSpace(logicStr))
                return GroupType.And;

            string s = logicStr.Trim().ToLowerInvariant();
            return s switch
            {
                "or" or "və ya" or "ve ya" => GroupType.Or,
                "notand" or "və deyil" or "ve deyil" => GroupType.NotAnd,
                "notor" or "və ya deyil" or "ve ya deyil" => GroupType.NotOr,
                _ => Enum.TryParse<GroupType>(logicStr, true, out var gt) ? gt : GroupType.And
            };
        }

        public static object? ConvertValue(string raw, Type targetType)
        {
            if (string.IsNullOrWhiteSpace(raw)) return null;

            try
            {
                Type underlying = Nullable.GetUnderlyingType(targetType) ?? targetType;

                if (underlying == typeof(string)) return raw;
                if (underlying == typeof(int)) return int.Parse(raw, NumberStyles.Any, CultureInfo.InvariantCulture);
                if (underlying == typeof(long)) return long.Parse(raw, NumberStyles.Any, CultureInfo.InvariantCulture);
                if (underlying == typeof(short)) return short.Parse(raw, NumberStyles.Any, CultureInfo.InvariantCulture);
                if (underlying == typeof(byte)) return byte.Parse(raw, NumberStyles.Any, CultureInfo.InvariantCulture);
                if (underlying == typeof(decimal))
                {
                    string normalized = raw.Replace(',', '.');
                    return decimal.Parse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture);
                }
                if (underlying == typeof(double))
                {
                    string normalized = raw.Replace(',', '.');
                    return double.Parse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture);
                }
                if (underlying == typeof(float))
                {
                    string normalized = raw.Replace(',', '.');
                    return float.Parse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture);
                }
                if (underlying == typeof(DateTime))
                {
                    if (DateTime.TryParse(raw, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                        return dt;
                    return DateTime.Parse(raw);
                }
                if (underlying == typeof(bool))
                {
                    if (raw == "1" || raw.Equals("true", StringComparison.OrdinalIgnoreCase) || raw.Equals("bəli", StringComparison.OrdinalIgnoreCase) || raw.Equals("beli", StringComparison.OrdinalIgnoreCase))
                        return true;
                    if (raw == "0" || raw.Equals("false", StringComparison.OrdinalIgnoreCase) || raw.Equals("xeyr", StringComparison.OrdinalIgnoreCase))
                        return false;
                    return bool.Parse(raw);
                }
                if (underlying == typeof(Guid))
                    return Guid.Parse(raw);
                if (underlying.IsEnum)
                    return Enum.Parse(underlying, raw, true);

                return Convert.ChangeType(raw, underlying, CultureInfo.InvariantCulture);
            }
            catch
            {
                return raw;
            }
        }

        #endregion
    }
}
