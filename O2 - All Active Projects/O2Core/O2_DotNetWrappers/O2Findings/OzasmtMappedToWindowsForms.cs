using System;
using System.Reflection;
using System.Windows.Forms;
using O2.Kernel.Interfaces.O2Findings;

namespace O2.DotNetWrappers.O2Findings
{
    public class OzasmtMappedToWindowsForms
    {
        public static void showO2FindingInDataGridView(O2Finding o2Finding, DataGridView dataGridView)
        {
        }

        public static void showO2TraceInTreeView(O2Trace o2Trace, DataGridView dataGridView, String showItem)
        {
        }

        public static void showO2TraceInDataGridView(O2Trace o2Trace, DataGridView dataGridView)
        {
        }

        public static void loadIntoToolStripCombox_O2FindingFieldsNames(ToolStripComboBox comboBox, string defaultValue)
        {
            comboBox.Items.Clear();
            foreach (PropertyInfo property in typeof (O2Finding).GetProperties())
                comboBox.Items.Add(property.Name);
            comboBox.Text = defaultValue;
        }

        public static void loadIntoToolStripCombox_O2TraceTypes(ToolStripComboBox comboBox)
        {
            comboBox.Items.Clear();

            foreach (object value in Enum.GetValues(typeof (TraceType)))
                comboBox.Items.Add(value);
        }
    }
}