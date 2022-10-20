using System;
using System.Collections.Generic;
using System.Text;

namespace QuesAnsLib.BusinessObjects
{
    public class QuestionBO
    {
        #region Property
        public Guid Id { get; set; }
        public string QuesTitle { get; set; }
        public string QuesDescription { get; set; }
        public DateTime QuesTime { get; set; }

        //--------------FK------------------------------
        public Guid QuesById { get; set; }
        #endregion
    }
}
