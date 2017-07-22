using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RapidWarehouse
{
    public class FormUltils
    {
        private static FormUltils utils;

        public static FormUltils getInstance()
        {
            if(utils == null)
            {
                utils = new FormUltils();
            }

            return utils;
        }

        public void GobackHome(System.Windows.Forms.Form form)
        {
            Program.Container.GetInstance<FormHome>().Show();
            form.Dispose();
        }

        public string GetFormText()
        {
            return string.Format("Kho hàng {0} - {1}", FormLogin.mWarehouse.Name, GetVersionInfo());
        }

        public string GetVersionInfo()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion==null ?"1.0.0.0": fvi.FileVersion;

            return "Rapid Warehouse v" + version;
        }
    }
}
