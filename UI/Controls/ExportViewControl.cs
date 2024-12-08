﻿using MWarehouse.Contract.Service.Interface;
using MWarehouse.Service.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class ExportViewControl : UserControl
    {
        private readonly IPDFExportService _wordService;
        private readonly IExcelExportService _excelService;
        public ExportViewControl(IPDFExportService wordService, IExcelExportService _excelService)
        {
            this._wordService = wordService;
            this._excelService = _excelService;
            InitializeComponent();
        }
    }
}
