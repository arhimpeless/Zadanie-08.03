using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_08._03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void RefreshListBox()
        {
            listBox1.Items.Clear();
            List<Table> tables = ListTables.Tables;
            for (int i = 0; i<tables.Count; i++)
            {
                listBox1.Items.Add($"стол №{i+1} \t" +
                    $"LB: {tables[i].GetLeftBottom()}\t" +
                    $"RB: {tables[i].GetRightBottom()}\t" +
                    $"RT: {tables[i].GetTopRight ()}\t" +
                    $"LT: {tables[i].GetTopLeft ()}.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            ListTables.AddTable();
            RefreshListBox();
            SetSelectIndex(listBox1.Items.Count - 1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshListBox();
        }
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            ListTables.RemoveTable(index);
            RefreshListBox();
            SetSelectIndex(index);
        }
        private void SetSelectIndex(int index)
        {
            if (index >= listBox1.Items.Count)
            {
                index -= 1;
            }
            listBox1.SelectedIndex = index;
        }
        private void btnTurnRight_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            var table = ListTables.Tables[index];
            table.TurnRight();
            //RefreshListBox();
            //SetSelectIndex(index);
            listBox1.Items[index] = $"стол №{index + 1} \t" +
                    $"LB: {table.GetLeftBottom()}\t" +
                    $"RB: {table.GetRightBottom()}\t" +
                    $"RT: {table.GetTopRight()}\t" +
                    $"LT: {table.GetTopLeft()}.";
        }

        private void btnTurnLeft_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            var table = ListTables.Tables[index];
            table.TurnLeft();
            listBox1.Items[index] = $"стол №{index + 1} \t" +
                    $"LB: {table.GetLeftBottom()}\t" +
                    $"RB: {table.GetRightBottom()}\t" +
                    $"RT: {table.GetTopRight()}\t" +
                    $"LT: {table.GetTopLeft()}.";
        }

    }
}
