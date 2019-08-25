using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Common
{
    public class EditorSettingDTO
    { 
        public string LineNumbers { get; set; } = "on";
        public bool RoundedSelection { get; set; } = false;
        public bool ScrollBeyondLastLine { get; set; } = false;
        public bool ReadOnly { get; set; } = false;
        public int FontSize { get; set; } = 20;
        public int TabSize { get; set; } = 5;
        public string CursorStyle { get; set; } = "line";
        public int LineHeight { get; set; } = 20;
        public string Theme { get; set; } = "vs";
    }
}
