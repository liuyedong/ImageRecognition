using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinOcr
{
    public class OcrResult
    {
        public string log_id { get; set; }
        public int words_result_num { get; set; }

        public List<RetData> words_result { get; set; }
    }
}
