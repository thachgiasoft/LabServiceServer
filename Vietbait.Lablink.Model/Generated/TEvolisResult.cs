using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Xml.Serialization;
using SubSonic;

// <auto-generated />

namespace Vietbait.Lablink.Model
{
    /// <summary>
    ///     Strongly-typed collection for the TEvolisResult class.
    /// </summary>
    [Serializable]
    public class TEvolisResultCollection : ActiveList<TEvolisResult, TEvolisResultCollection>
    {
        /// <summary>
        ///     Filters an existing collection based on the set criteria. This is an in-memory filter
        ///     Thanks to developingchris for this!
        /// </summary>
        /// <returns>TEvolisResultCollection</returns>
        public TEvolisResultCollection Filter()
        {
            for (int i = Count - 1; i > -1; i--)
            {
                TEvolisResult o = this[i];
                foreach (Where w in wheres)
                {
                    bool remove = false;
                    PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
    }

    /// <summary>
    ///     This is an ActiveRecord class which wraps the T_Evolis_Result table.
    /// </summary>
    [Serializable]
    public class TEvolisResult : ActiveRecord<TEvolisResult>, IActiveRecord
    {
        #region .ctors and Default Settings

        public TEvolisResult()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }

        public TEvolisResult(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }

        public TEvolisResult(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public TEvolisResult(string columnName, object columnValue)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByParam(columnName, columnValue);
        }

        private void InitSetDefaults()
        {
            SetDefaults();
        }

        protected static void SetSQLProps()
        {
            GetTableSchema();
        }

        #endregion

        #region Schema and Query Accessor	

        public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                    SetSQLProps();
                return BaseSchema;
            }
        }

        public static Query CreateQuery()
        {
            return new Query(Schema);
        }

        private static void GetTableSchema()
        {
            if (!IsSchemaInitialized)
            {
                //Schema declaration
                var schema = new TableSchema.Table("T_Evolis_Result", TableType.Table, DataService.GetInstance("ORM"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns

                var colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
                colvarId.DataType = DbType.Int64;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = true;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = true;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                colvarId.DefaultSetting = @"";
                colvarId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarId);

                var colvarDetailID = new TableSchema.TableColumn(schema);
                colvarDetailID.ColumnName = "DetailID";
                colvarDetailID.DataType = DbType.Int64;
                colvarDetailID.MaxLength = 0;
                colvarDetailID.AutoIncrement = false;
                colvarDetailID.IsNullable = false;
                colvarDetailID.IsPrimaryKey = false;
                colvarDetailID.IsForeignKey = false;
                colvarDetailID.IsReadOnly = false;
                colvarDetailID.DefaultSetting = @"";
                colvarDetailID.ForeignKeyTableName = "";
                schema.Columns.Add(colvarDetailID);

                var colvarPatientID = new TableSchema.TableColumn(schema);
                colvarPatientID.ColumnName = "PatientID";
                colvarPatientID.DataType = DbType.String;
                colvarPatientID.MaxLength = 50;
                colvarPatientID.AutoIncrement = false;
                colvarPatientID.IsNullable = true;
                colvarPatientID.IsPrimaryKey = false;
                colvarPatientID.IsForeignKey = false;
                colvarPatientID.IsReadOnly = false;
                colvarPatientID.DefaultSetting = @"";
                colvarPatientID.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPatientID);

                var colvarBarcode = new TableSchema.TableColumn(schema);
                colvarBarcode.ColumnName = "Barcode";
                colvarBarcode.DataType = DbType.String;
                colvarBarcode.MaxLength = 50;
                colvarBarcode.AutoIncrement = false;
                colvarBarcode.IsNullable = true;
                colvarBarcode.IsPrimaryKey = false;
                colvarBarcode.IsForeignKey = false;
                colvarBarcode.IsReadOnly = false;
                colvarBarcode.DefaultSetting = @"";
                colvarBarcode.ForeignKeyTableName = "";
                schema.Columns.Add(colvarBarcode);

                var colvarTestName = new TableSchema.TableColumn(schema);
                colvarTestName.ColumnName = "TestName";
                colvarTestName.DataType = DbType.String;
                colvarTestName.MaxLength = 50;
                colvarTestName.AutoIncrement = false;
                colvarTestName.IsNullable = true;
                colvarTestName.IsPrimaryKey = false;
                colvarTestName.IsForeignKey = false;
                colvarTestName.IsReadOnly = false;
                colvarTestName.DefaultSetting = @"";
                colvarTestName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTestName);

                var colvarWell = new TableSchema.TableColumn(schema);
                colvarWell.ColumnName = "Well";
                colvarWell.DataType = DbType.String;
                colvarWell.MaxLength = 50;
                colvarWell.AutoIncrement = false;
                colvarWell.IsNullable = true;
                colvarWell.IsPrimaryKey = false;
                colvarWell.IsForeignKey = false;
                colvarWell.IsReadOnly = false;
                colvarWell.DefaultSetting = @"";
                colvarWell.ForeignKeyTableName = "";
                schema.Columns.Add(colvarWell);

                var colvarFlag = new TableSchema.TableColumn(schema);
                colvarFlag.ColumnName = "Flag";
                colvarFlag.DataType = DbType.String;
                colvarFlag.MaxLength = 50;
                colvarFlag.AutoIncrement = false;
                colvarFlag.IsNullable = true;
                colvarFlag.IsPrimaryKey = false;
                colvarFlag.IsForeignKey = false;
                colvarFlag.IsReadOnly = false;
                colvarFlag.DefaultSetting = @"";
                colvarFlag.ForeignKeyTableName = "";
                schema.Columns.Add(colvarFlag);

                var colvarValueX = new TableSchema.TableColumn(schema);
                colvarValueX.ColumnName = "Value";
                colvarValueX.DataType = DbType.String;
                colvarValueX.MaxLength = 50;
                colvarValueX.AutoIncrement = false;
                colvarValueX.IsNullable = true;
                colvarValueX.IsPrimaryKey = false;
                colvarValueX.IsForeignKey = false;
                colvarValueX.IsReadOnly = false;
                colvarValueX.DefaultSetting = @"";
                colvarValueX.ForeignKeyTableName = "";
                schema.Columns.Add(colvarValueX);

                var colvarSco = new TableSchema.TableColumn(schema);
                colvarSco.ColumnName = "SCO";
                colvarSco.DataType = DbType.String;
                colvarSco.MaxLength = 50;
                colvarSco.AutoIncrement = false;
                colvarSco.IsNullable = true;
                colvarSco.IsPrimaryKey = false;
                colvarSco.IsForeignKey = false;
                colvarSco.IsReadOnly = false;
                colvarSco.DefaultSetting = @"";
                colvarSco.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSco);

                var colvarResult = new TableSchema.TableColumn(schema);
                colvarResult.ColumnName = "Result";
                colvarResult.DataType = DbType.String;
                colvarResult.MaxLength = 50;
                colvarResult.AutoIncrement = false;
                colvarResult.IsNullable = true;
                colvarResult.IsPrimaryKey = false;
                colvarResult.IsForeignKey = false;
                colvarResult.IsReadOnly = false;
                colvarResult.DefaultSetting = @"";
                colvarResult.ForeignKeyTableName = "";
                schema.Columns.Add(colvarResult);

                var colvarTestNumber = new TableSchema.TableColumn(schema);
                colvarTestNumber.ColumnName = "TestNumber";
                colvarTestNumber.DataType = DbType.Int32;
                colvarTestNumber.MaxLength = 0;
                colvarTestNumber.AutoIncrement = false;
                colvarTestNumber.IsNullable = true;
                colvarTestNumber.IsPrimaryKey = false;
                colvarTestNumber.IsForeignKey = false;
                colvarTestNumber.IsReadOnly = false;
                colvarTestNumber.DefaultSetting = @"";
                colvarTestNumber.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTestNumber);

                var colvarReasonId = new TableSchema.TableColumn(schema);
                colvarReasonId.ColumnName = "ReasonId";
                colvarReasonId.DataType = DbType.Int32;
                colvarReasonId.MaxLength = 0;
                colvarReasonId.AutoIncrement = false;
                colvarReasonId.IsNullable = true;
                colvarReasonId.IsPrimaryKey = false;
                colvarReasonId.IsForeignKey = false;
                colvarReasonId.IsReadOnly = false;
                colvarReasonId.DefaultSetting = @"";
                colvarReasonId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarReasonId);

                var colvarBarcodeRerun = new TableSchema.TableColumn(schema);
                colvarBarcodeRerun.ColumnName = "BarcodeRerun";
                colvarBarcodeRerun.DataType = DbType.String;
                colvarBarcodeRerun.MaxLength = 50;
                colvarBarcodeRerun.AutoIncrement = false;
                colvarBarcodeRerun.IsNullable = true;
                colvarBarcodeRerun.IsPrimaryKey = false;
                colvarBarcodeRerun.IsForeignKey = false;
                colvarBarcodeRerun.IsReadOnly = false;
                colvarBarcodeRerun.DefaultSetting = @"";
                colvarBarcodeRerun.ForeignKeyTableName = "";
                schema.Columns.Add(colvarBarcodeRerun);

                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ORM"].AddSchema("T_Evolis_Result", schema);
            }
        }

        #endregion

        #region Props

        [XmlAttribute("Id")]
        [Bindable(true)]
        public long Id
        {
            get { return GetColumnValue<long>(Columns.Id); }
            set { SetColumnValue(Columns.Id, value); }
        }

        [XmlAttribute("DetailID")]
        [Bindable(true)]
        public long DetailID
        {
            get { return GetColumnValue<long>(Columns.DetailID); }
            set { SetColumnValue(Columns.DetailID, value); }
        }

        [XmlAttribute("PatientID")]
        [Bindable(true)]
        public string PatientID
        {
            get { return GetColumnValue<string>(Columns.PatientID); }
            set { SetColumnValue(Columns.PatientID, value); }
        }

        [XmlAttribute("Barcode")]
        [Bindable(true)]
        public string Barcode
        {
            get { return GetColumnValue<string>(Columns.Barcode); }
            set { SetColumnValue(Columns.Barcode, value); }
        }

        [XmlAttribute("TestName")]
        [Bindable(true)]
        public string TestName
        {
            get { return GetColumnValue<string>(Columns.TestName); }
            set { SetColumnValue(Columns.TestName, value); }
        }

        [XmlAttribute("Well")]
        [Bindable(true)]
        public string Well
        {
            get { return GetColumnValue<string>(Columns.Well); }
            set { SetColumnValue(Columns.Well, value); }
        }

        [XmlAttribute("Flag")]
        [Bindable(true)]
        public string Flag
        {
            get { return GetColumnValue<string>(Columns.Flag); }
            set { SetColumnValue(Columns.Flag, value); }
        }

        [XmlAttribute("ValueX")]
        [Bindable(true)]
        public string ValueX
        {
            get { return GetColumnValue<string>(Columns.ValueX); }
            set { SetColumnValue(Columns.ValueX, value); }
        }

        [XmlAttribute("Sco")]
        [Bindable(true)]
        public string Sco
        {
            get { return GetColumnValue<string>(Columns.Sco); }
            set { SetColumnValue(Columns.Sco, value); }
        }

        [XmlAttribute("Result")]
        [Bindable(true)]
        public string Result
        {
            get { return GetColumnValue<string>(Columns.Result); }
            set { SetColumnValue(Columns.Result, value); }
        }

        [XmlAttribute("TestNumber")]
        [Bindable(true)]
        public int? TestNumber
        {
            get { return GetColumnValue<int?>(Columns.TestNumber); }
            set { SetColumnValue(Columns.TestNumber, value); }
        }

        [XmlAttribute("ReasonId")]
        [Bindable(true)]
        public int? ReasonId
        {
            get { return GetColumnValue<int?>(Columns.ReasonId); }
            set { SetColumnValue(Columns.ReasonId, value); }
        }

        [XmlAttribute("BarcodeRerun")]
        [Bindable(true)]
        public string BarcodeRerun
        {
            get { return GetColumnValue<string>(Columns.BarcodeRerun); }
            set { SetColumnValue(Columns.BarcodeRerun, value); }
        }

        #endregion

        #region ObjectDataSource support

        /// <summary>
        ///     Inserts a record, can be used with the Object Data Source
        /// </summary>
        public static void Insert(long varDetailID, string varPatientID, string varBarcode, string varTestName,
            string varWell, string varFlag, string varValueX, string varSco, string varResult,
            int? varTestNumber, int? varReasonId, string varBarcodeRerun)
        {
            var item = new TEvolisResult();

            item.DetailID = varDetailID;

            item.PatientID = varPatientID;

            item.Barcode = varBarcode;

            item.TestName = varTestName;

            item.Well = varWell;

            item.Flag = varFlag;

            item.ValueX = varValueX;

            item.Sco = varSco;

            item.Result = varResult;

            item.TestNumber = varTestNumber;

            item.ReasonId = varReasonId;

            item.BarcodeRerun = varBarcodeRerun;


            if (HttpContext.Current != null)
                item.Save(HttpContext.Current.User.Identity.Name);
            else
                item.Save(Thread.CurrentPrincipal.Identity.Name);
        }

        /// <summary>
        ///     Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(long varId, long varDetailID, string varPatientID, string varBarcode,
            string varTestName, string varWell, string varFlag, string varValueX, string varSco,
            string varResult, int? varTestNumber, int? varReasonId, string varBarcodeRerun)
        {
            var item = new TEvolisResult();

            item.Id = varId;

            item.DetailID = varDetailID;

            item.PatientID = varPatientID;

            item.Barcode = varBarcode;

            item.TestName = varTestName;

            item.Well = varWell;

            item.Flag = varFlag;

            item.ValueX = varValueX;

            item.Sco = varSco;

            item.Result = varResult;

            item.TestNumber = varTestNumber;

            item.ReasonId = varReasonId;

            item.BarcodeRerun = varBarcodeRerun;

            item.IsNew = false;
            if (HttpContext.Current != null)
                item.Save(HttpContext.Current.User.Identity.Name);
            else
                item.Save(Thread.CurrentPrincipal.Identity.Name);
        }

        #endregion

        #region Typed Columns

        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }


        public static TableSchema.TableColumn DetailIDColumn
        {
            get { return Schema.Columns[1]; }
        }


        public static TableSchema.TableColumn PatientIDColumn
        {
            get { return Schema.Columns[2]; }
        }


        public static TableSchema.TableColumn BarcodeColumn
        {
            get { return Schema.Columns[3]; }
        }


        public static TableSchema.TableColumn TestNameColumn
        {
            get { return Schema.Columns[4]; }
        }


        public static TableSchema.TableColumn WellColumn
        {
            get { return Schema.Columns[5]; }
        }


        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[6]; }
        }


        public static TableSchema.TableColumn ValueXColumn
        {
            get { return Schema.Columns[7]; }
        }


        public static TableSchema.TableColumn ScoColumn
        {
            get { return Schema.Columns[8]; }
        }


        public static TableSchema.TableColumn ResultColumn
        {
            get { return Schema.Columns[9]; }
        }


        public static TableSchema.TableColumn TestNumberColumn
        {
            get { return Schema.Columns[10]; }
        }


        public static TableSchema.TableColumn ReasonIdColumn
        {
            get { return Schema.Columns[11]; }
        }


        public static TableSchema.TableColumn BarcodeRerunColumn
        {
            get { return Schema.Columns[12]; }
        }

        #endregion

        #region Columns Struct

        public struct Columns
        {
            public static string Id = @"ID";
            public static string DetailID = @"DetailID";
            public static string PatientID = @"PatientID";
            public static string Barcode = @"Barcode";
            public static string TestName = @"TestName";
            public static string Well = @"Well";
            public static string Flag = @"Flag";
            public static string ValueX = @"Value";
            public static string Sco = @"SCO";
            public static string Result = @"Result";
            public static string TestNumber = @"TestNumber";
            public static string ReasonId = @"ReasonId";
            public static string BarcodeRerun = @"BarcodeRerun";
        }

        #endregion

        #region Update PK Collections

        #endregion

        #region Deep Save

        #endregion

        //no foreign key tables defined (0)


        //no ManyToMany tables defined (0)
    }
}