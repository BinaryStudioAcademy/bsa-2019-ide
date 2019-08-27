using IDE.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Common
{
    public class EditorSettingDTO
    { 
        public int? Id { get; set; }
        public string LineNumbers { get; set; }
        public bool RoundedSelection { get; set; }
        public bool ScrollBeyondLastLine { get; set; }
        public string Language { get; set; }
        public bool ReadOnly { get; set; }
        public int FontSize { get; set; }
        public int TabSize { get; set; }
        public string CursorStyle { get; set; }
        public int LineHeight { get; set; }
        public string Theme { get; set; }
    }
}
