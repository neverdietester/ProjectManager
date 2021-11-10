using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    public class HelperBase
    {
        protected readonly AppManager app;

        public string Title => app.Browser.Title;

        public HelperBase(AppManager app)
        {
            this.app = app;
        }
    }
}