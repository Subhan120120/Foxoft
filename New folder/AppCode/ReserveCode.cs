
//private void Form1_KeyDown(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.F3)
//    {
//        Control control = this.FindFocusedControl(this);
//        if (control.GetType() == typeof(LookUpEdit) || control.Parent.GetType() == typeof(LookUpEdit))
//        {
//            LookUpEdit lue;
//            lue = control as LookUpEdit;
//            if (lue == null)
//            {
//                lue = control.Parent as LookUpEdit;
//            }
//            lue.Text = "BlaBlaBla";
//        }

//    }
//}
//public Control FindFocusedControl(Control control)
//{
//    ContainerControl container = control as ContainerControl;
//    while (container != null)
//    {
//        control = container.ActiveControl;
//        container = control as ContainerControl;
//    }
//    return control;
//}


//gridView1.Appearance.HideSelectionRow.Assign(gridView1.Appearance.FocusedRow); 


//private void textEditNetAmount_Validating(object sender, CancelEventArgs e)
//{
//    Validate_BetweenMinAndMaxRule(sender as BaseEdit, 0, Amount);
//}
//private void Validate_BetweenMinAndMaxRule(BaseEdit control, decimal min, decimal max)
//{
//    decimal val = Convert.ToDecimal(control.EditValue.ToString());
//    if ((val < min)) dxErrorProvider1.SetError(control, "Endirim ədədi " + (min).ToString() + " dan böyük olmalıdır ", ErrorType.Critical);
//    else if (val > max) dxErrorProvider1.SetError(control, "Endirim ədədi " + (max).ToString() + " dən kiçik olmalıdır ", ErrorType.Critical);
//    else dxErrorProvider1.SetError(control, "");
//}


//public SqlDataSource BindToDataCopy(string invoiceHeaderId)
//{
//    CustomStringConnectionParameters connectionParameters = new CustomStringConnectionParameters(subConnString);

//    SqlDataSource ds = new SqlDataSource(connectionParameters);
//    CustomSqlQuery query = new CustomSqlQuery();
//    query.Name = "customQuery1";
//    query.Sql = "select TrInvoiceLine.*, ProductDescription, Barcode from TrInvoiceLine " +
//        "left join DcProduct on TrInvoiceLine.ProductCode = DcProduct.ProductCode " +
//        "where InvoiceHeaderId = '" + invoiceHeaderId + "' order by CreatedDate"; // burdaki kolonlari dizaynda da elave et

//    ds.Queries.Add(query);
//    ds.Fill();
//    return ds;
//}

//private void textEditCash_Validating(object sender, CancelEventArgs e)
//{
//    TextEdit textEdit = sender as TextEdit;
//    decimal val = Convert.ToDecimal(textEdit.EditValue);
//    if (val < 0)
//        e.Cancel = true;
//}