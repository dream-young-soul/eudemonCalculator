// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="231216@nd">
//   
// </copyright>
// <summary>
//   Defines the Form1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using eudemonCalculator.lib;


namespace eudemonCalculator
{
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>TODO The form 1.</summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取logBox上文本
        /// </summary>
        /// <returns></returns>
        public string LogBoxText
        {
            get
            {
                var text = string.Empty;
                foreach (string itemValue in logBox.Items)
                {
                    text = text + itemValue + "\n";
                }
                return text;
            }
        }

        /// <summary>
        /// 平方公式
        /// </summary>
        /// <param name="reality"></param>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns>e</returns>
        public double Squareformula(double reality, double a, double c)
        {
            double e;
            if (reality > a)
            {
                e = Math.Pow(reality - a, 2) * c / 100000;
                logBox.Items.Add($"({reality} - {a}) ^ 2 * {c} / 100000");
            }
            else
            {
                e = (-1) * Math.Pow(reality - a, 2) * c / 300000;
                logBox.Items.Add($"(-1) * ({reality} - {a}) ^ 2 * {c} / 300000");
            }

            return e;
        }

        /// <summary>
        /// 幸运分公式
        /// </summary>
        /// <param name="reality"></param>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns>e</returns>
        public double LuckValue(double reality, double a, double c)
        {
            var e = (reality - a) * c / 100;
            return e;
        }

        /// <summary>
        /// 正比公式
        /// </summary>
        /// <param name="reality"></param>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns>e</returns>
        public double Directratio(double reality, double a, double c)
        {
            double e;
            if (reality > a)
            {
                e = (reality - a) * c / 1000;
                logBox.Items.Add($"({reality} - {a}) * {c} / 1000");
            }
            else
            {
                e = (reality - a) * c / 5000;
                if (e < -20)
                {
                    e = -20;
                }

                logBox.Items.Add($"({reality} - {a}) * {c} / 5000");
                logBox.Items.Add("if(e < -20){e = -20}");
            }

            return e;
        }

        /// <summary>
        /// 1.5次方公式
        /// </summary>
        /// <param name="reality"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>e</returns>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1407:ArithmeticExpressionsMustDeclarePrecedence", Justification = "Reviewed. Suppression is OK here.")]
        public double Power(double reality, double a, double b, double c)
        {
            // int[] specialId =
            // {
            // 107, 907, 142, 942, 152, 952, 186, 986, 293, 693, 202, 602, 212, 612, 203, 603, 213, 613, 204, 604, 214,
            // 614, 305, 705, 304, 704, 303, 703, 302, 702, 301, 701, 300, 700, 295, 695, 350, 750, 223, 623, 258, 658,
            // 257, 657, 208, 608, 228, 628, 296, 696, 137, 937, 138, 938
            // };
            // var threeId = Convert.ToInt32(eudemonID.Text.Substring(eudemonID.Text.Length - 3));
            // var exists = ((IList)specialId).Contains(threeId);
            // return exists ? 1 : 0;
            double e;
            if (reality - a > b - a)
            {
                e = Math.Pow(b / 10000 - a / 10000, 1.5) * c / 100000 + (a / 10000 - b / 10000) / 10 *
                        Math.Pow(b / 10000 - b / 10000, 0.5) * c / 50000;
                logBox.Items.Add(
                    $"({b} / 10000 - {a} / 10000) ^ 1.5 * {c} / 100000 + ({a} / 10000 - {b} / 10000) / 10 * ({b} / 10000 - {a} / 10000) ^ 0.5 * {c} / 50000 ");
            }
            else if (reality > a)
            {
                e = Math.Pow(reality / 10000 - a / 10000, 1.5) * c / 100000;
                logBox.Items.Add($"({reality} / 10000 - {a} / 10000) ^ 1.5 * {c} / 100000");
            }
            else
            {
                e = (-1) * Math.Pow(reality / 10000 - a / 10000, 2) * c / 300000;
                logBox.Items.Add($"(-1) * ({reality} / 10000 - {a} / 10000) ^ 2 * {c} / 300000");
            }

            return e;
        }

        /// <summary>
        /// 生命成长率（特殊公式）
        /// </summary>
        /// <param name="reality"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>e</returns>
        public static double LifePower(double reality, double a, double b, double c)
        {
            if (reality - a > b - a)
            {
                var e = Math.Pow(b / 1000 - a / 1000, 1.5) * c / 100000 + (a / 10000 - b / 1000) / 10 *
                        Math.Pow(b / 1000 - b / 1000, 0.5) * c / 50000;
                return e;
            }
            else if (reality > a)
            {
                var e = Math.Pow(reality / 10000 - a / 1000, 1.5) * c / 100000;
                return e;
            }
            else
            {
                var e = (-1) * Math.Pow(reality / 10000 - a / 1000, 2) * c / 300000;
                return e;
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (Database.Text == string.Empty)
            {
                MessageBox.Show(@"请输入数据库名称", @"提示");
                return;
            }
            try
            {
                MySqlHelper.InitConnectStr(Database.Text);
                var check = MySqlHelper.GetDataSet(
                    "select a.id,a.name from cq_itemtype a,cq_grade b where a.id = b.id group by name");
                var dataCheckResult = check.Tables["Table1"].Rows;
                Console.WriteLine(dataCheckResult[0].ItemArray[0]);
                MessageBox.Show(@"连接成功", @"提示");
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void GetNature_Click(object sender, EventArgs e)
        {
            if (eudemonID.Text == string.Empty)
            {
                MessageBox.Show(@"请输入幻兽ID", @"提示");
                return;
            }
            try
            {
                MySqlHelper.InitConnectStr(Database.Text);
                var eudName =
                    MySqlHelper.GetDataSet("select name from cq_itemtype a,cq_grade b where a.id = b.id and b.id =" +
                                           eudemonID.Text);
                var dataNameResult = eudName.Tables["Table1"].Rows;
                eudemon_name.Text = Encoding.GetEncoding("gbk").GetString((byte[])dataNameResult[0].ItemArray[0]);

                var ds = MySqlHelper.GetDataSet(
                    @"select life_a,life_b,life_c,life_grow_a,life_grow_b,life_grow_c,phy_min_a,phy_min_b,phy_min_c,
            phy_min_grow_a, phy_min_grow_b, phy_min_grow_c, phy_max_a, phy_max_b, phy_max_c, phy_max_grow_a, phy_max_grow_b, phy_max_grow_c,
            phy_def_a, phy_def_b, phy_def_c, phy_def_grow_a, phy_def_grow_b, phy_def_grow_c, mgc_min_a, mgc_min_b, mgc_min_c,
            mgc_min_grow_a, mgc_min_grow_b, mgc_min_grow_c, mgc_max_a, mgc_max_b, mgc_max_c, mgc_max_grow_a, mgc_max_grow_b, mgc_max_grow_c,
            mgc_def_a, mgc_def_b, mgc_def_c, mgc_def_grow_a, mgc_def_grow_b, mgc_def_grow_c, luck_a, luck_b, luck_c,
            major_attr_a, major_attr_b, major_attr_c, minor_attr1_a, minor_attr1_b, minor_attr1_c, minor_attr2_a, minor_attr2_b, minor_attr2_c
                from cq_grade where id = " + eudemonID.Text);
                var dataRowCollection = ds.Tables["Table1"].Rows;
                Life_A.Text = dataRowCollection[0].ItemArray[0].ToString();
                Life_B.Text = dataRowCollection[0].ItemArray[1].ToString();
                Life_C.Text = dataRowCollection[0].ItemArray[2].ToString();
                Life_Grow_A.Text = dataRowCollection[0].ItemArray[3].ToString();
                Life_Grow_B.Text = dataRowCollection[0].ItemArray[4].ToString();
                Life_Grow_C.Text = dataRowCollection[0].ItemArray[5].ToString();
                Phyatk_Min_A.Text = dataRowCollection[0].ItemArray[6].ToString();
                Phyatk_Min_B.Text = dataRowCollection[0].ItemArray[7].ToString();
                Phyatk_Min_C.Text = dataRowCollection[0].ItemArray[8].ToString();
                Phyatk_Min_Grow_A.Text = dataRowCollection[0].ItemArray[9].ToString();
                Phyatk_Min_Grow_B.Text = dataRowCollection[0].ItemArray[10].ToString();
                Phyatk_Min_Grow_C.Text = dataRowCollection[0].ItemArray[11].ToString();
                Phyatk_Max_A.Text = dataRowCollection[0].ItemArray[12].ToString();
                Phyatk_Max_B.Text = dataRowCollection[0].ItemArray[13].ToString();
                Phyatk_Max_C.Text = dataRowCollection[0].ItemArray[14].ToString();
                Phyatk_Max_Grow_A.Text = dataRowCollection[0].ItemArray[15].ToString();
                Phyatk_Max_Grow_B.Text = dataRowCollection[0].ItemArray[16].ToString();
                Phyatk_Max_Grow_C.Text = dataRowCollection[0].ItemArray[17].ToString();
                Phy_Def_A.Text = dataRowCollection[0].ItemArray[18].ToString();
                Phy_Def_B.Text = dataRowCollection[0].ItemArray[19].ToString();
                Phy_Def_C.Text = dataRowCollection[0].ItemArray[20].ToString();
                Phy_Def_Grow_A.Text = dataRowCollection[0].ItemArray[21].ToString();
                Phy_Def_Grow_B.Text = dataRowCollection[0].ItemArray[22].ToString();
                Phy_Def_Grow_C.Text = dataRowCollection[0].ItemArray[23].ToString();
                Magatk_Min_A.Text = dataRowCollection[0].ItemArray[24].ToString();
                Magatk_Min_B.Text = dataRowCollection[0].ItemArray[25].ToString();
                Magatk_Min_C.Text = dataRowCollection[0].ItemArray[26].ToString();
                Magatk_Min_Grow_A.Text = dataRowCollection[0].ItemArray[27].ToString();
                Magatk_Min_Grow_B.Text = dataRowCollection[0].ItemArray[28].ToString();
                Magatk_Min_Grow_C.Text = dataRowCollection[0].ItemArray[29].ToString();
                Mgcatk_Max_A.Text = dataRowCollection[0].ItemArray[30].ToString();
                Mgcatk_Max_B.Text = dataRowCollection[0].ItemArray[31].ToString();
                Mgcatk_Max_C.Text = dataRowCollection[0].ItemArray[32].ToString();
                Mgcatk_Max_Grow_A.Text = dataRowCollection[0].ItemArray[33].ToString();
                Mgcatk_Max_Grow_B.Text = dataRowCollection[0].ItemArray[34].ToString();
                Mgcatk_Max_Grow_C.Text = dataRowCollection[0].ItemArray[35].ToString();
                Mgc_Def_A.Text = dataRowCollection[0].ItemArray[36].ToString();
                Mgc_Def_B.Text = dataRowCollection[0].ItemArray[37].ToString();
                Mgc_Def_C.Text = dataRowCollection[0].ItemArray[38].ToString();
                Mgc_Def_Grow_A.Text = dataRowCollection[0].ItemArray[39].ToString();
                Mgc_Def_Grow_B.Text = dataRowCollection[0].ItemArray[40].ToString();
                Mgc_Def_Grow_C.Text = dataRowCollection[0].ItemArray[41].ToString();
                Luck_A.Text = dataRowCollection[0].ItemArray[42].ToString();
                Luck_B.Text = dataRowCollection[0].ItemArray[43].ToString();
                Luck_C.Text = dataRowCollection[0].ItemArray[44].ToString();
                major_attr_a.Text = dataRowCollection[0].ItemArray[45].ToString();
                major_attr_b.Text = dataRowCollection[0].ItemArray[46].ToString();
                major_attr_c.Text = dataRowCollection[0].ItemArray[47].ToString();
                minor_attr1_a.Text = dataRowCollection[0].ItemArray[48].ToString();
                minor_attr1_b.Text = dataRowCollection[0].ItemArray[49].ToString();
                minor_attr1_c.Text = dataRowCollection[0].ItemArray[50].ToString();
                minor_attr2_a.Text = dataRowCollection[0].ItemArray[51].ToString();
                minor_attr2_b.Text = dataRowCollection[0].ItemArray[52].ToString();
                minor_attr2_c.Text = dataRowCollection[0].ItemArray[53].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show(@"查询出错，请检查幻兽ID是否正确", @"警告");
            }
        }

        /// <summary>
        /// 限制输入为数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minor_attr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false; // 让操作生效  
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 计算按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void begin_Click(object sender, EventArgs e)
        {
            if (eudemon_name.Text == string.Empty)
            {
                MessageBox.Show(@"请先获取幻兽属性", @"提示");
                return;
            }

            if (Life.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("初始生命值：");
                Life_result.Text =
                    Squareformula(double.Parse(Life.Text), double.Parse(Life_A.Text), double.Parse(Life_C.Text))
                        .ToString(CultureInfo.InvariantCulture);
            }

            if (Life_Grow.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("\n生命成长率：");
                Life_Grow_result.Text = Power(
                    double.Parse(Life_Grow.Text),
                    double.Parse(Life_Grow_A.Text),
                    double.Parse(Life_Grow_B.Text),
                    double.Parse(Life_Grow_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Phyatk_Min.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("初始最小物理攻击：");
                Phyatk_Min_result.Text = Squareformula(
                    double.Parse(Phyatk_Min.Text),
                    double.Parse(Phyatk_Min_A.Text),
                    double.Parse(Phyatk_Min_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Phyatk_Min_Grow.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("最小物理攻击成长率：");
                Phyatk_Min_Grow_result.Text = Power(
                    double.Parse(Phyatk_Min_Grow.Text),
                    double.Parse(Phyatk_Min_Grow_A.Text),
                    double.Parse(Phyatk_Min_Grow_B.Text),
                    double.Parse(Phyatk_Min_Grow_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Phyatk_Max.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("初始最大物理攻击：");
                Phyatk_Max_result.Text = Squareformula(
                    double.Parse(Phyatk_Max.Text),
                    double.Parse(Phyatk_Max_A.Text),
                    double.Parse(Phyatk_Max_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Phyatk_Max_Grow.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("最大物理攻击成长率：");
                Phyatk_Max_Grow_result.Text = Power(
                    double.Parse(Phyatk_Max_Grow.Text),
                    double.Parse(Phyatk_Max_Grow_A.Text),
                    double.Parse(Phyatk_Max_Grow_B.Text),
                    double.Parse(Phyatk_Max_Grow_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Phy_Def.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("初始物理防御：");
                Phy_Def_result.Text = Squareformula(
                    double.Parse(Phy_Def.Text),
                    double.Parse(Phy_Def_A.Text),
                    double.Parse(Phy_Def_C.Text)).ToString(CultureInfo.InvariantCulture);
            }

            if (Phy_Def_Grow.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("物理防御成长率：");
                Phy_Def_Grow_result.Text = Power(
                    double.Parse(Phy_Def_Grow.Text),
                    double.Parse(Phy_Def_Grow_A.Text),
                    double.Parse(Phy_Def_Grow_B.Text),
                    double.Parse(Phy_Def_Grow_C.Text)).ToString(CultureInfo.InvariantCulture);
            }

            if (Magatk_Min.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("初始最小魔法攻击：");
                Magatk_Min_result.Text = Squareformula(
                    double.Parse(Magatk_Min.Text),
                    double.Parse(Magatk_Min_A.Text),
                    double.Parse(Magatk_Min_C.Text)).ToString(CultureInfo.InvariantCulture);
            }

            if (Magatk_Min_Grow.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("最小魔法攻击成长率：");
                Magatk_Min_Grow_result.Text = Power(
                    double.Parse(Magatk_Min_Grow.Text),
                    double.Parse(Magatk_Min_Grow_A.Text),
                    double.Parse(Magatk_Min_Grow_B.Text),
                    double.Parse(Magatk_Min_Grow_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Mgcatk_Max.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("初始最大魔法攻击：");
                Mgcatk_Max_result.Text = Squareformula(
                    double.Parse(Mgcatk_Max.Text),
                    double.Parse(Mgcatk_Max_A.Text),
                    double.Parse(Mgcatk_Max_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Mgcatk_Max_Grow.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("最大魔法攻击成长率：");
                Mgcatk_Max_Grow_result.Text = Power(
                    double.Parse(Mgcatk_Max_Grow.Text),
                    double.Parse(Mgcatk_Max_Grow_A.Text),
                    double.Parse(Mgcatk_Max_Grow_B.Text),
                    double.Parse(Mgcatk_Max_Grow_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Mgc_Def.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("初始魔法防御：");
                Mgc_Def_result.Text = Squareformula(
                    double.Parse(Mgc_Def.Text),
                    double.Parse(Mgc_Def_A.Text),
                    double.Parse(Mgc_Def_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Mgc_Def_Grow.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("魔法防御成长率：");
                Mgc_Def_Grow_result.Text = Power(
                    double.Parse(Mgc_Def_Grow.Text),
                    double.Parse(Mgc_Def_Grow_A.Text),
                    double.Parse(Mgc_Def_Grow_B.Text),
                    double.Parse(Mgc_Def_Grow_C.Text)).ToString(CultureInfo.InvariantCulture);
            }
            if (Luck.Text != string.Empty)
            {
                // Luck_result.Text =
                // LuckValue(double.Parse(Luck.Text), double.Parse(Luck_A.Text), double.Parse(Luck_C.Text))
                // .ToString(CultureInfo.InvariantCulture);
                Luck_result.Text = Luck.Text;
            }
            if (major_attr.Text != string.Empty)
            {
                logBox.Items.Add(string.Empty);
                logBox.Items.Add("超杀值：");
                major_attr_result.Text =
                    Directratio(double.Parse(Luck.Text), double.Parse(major_attr_a.Text), double.Parse(major_attr_c.Text))
                        .ToString(CultureInfo.InvariantCulture);
            }

            totalBox.Text = Life_result.Text + Life_Grow_result.Text + Phyatk_Min_result.Text
                            + Phyatk_Min_Grow_result.Text + Phyatk_Max_result.Text + Phyatk_Max_Grow_result.Text
                            + Phy_Def_result.Text + Phy_Def_Grow_result.Text + Magatk_Min_result.Text
                            + Magatk_Min_Grow_result.Text + Mgcatk_Max_result.Text + Mgcatk_Max_Grow_result.Text
                            + Mgc_Def_result.Text + Mgc_Def_Grow_result.Text + Luck_result.Text + major_attr_result.Text
                            + minor_attr1_result.Text + minor_attr2_result.Text;

            try
            {
                RunLog.WriteLog(LogBoxText);
            }
            catch (Exception ex)
            {
                logBox.Items.Add(ex.Message);
            }

        }


        /// <summary>
        /// 清空幻兽数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empty_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                }
                totalBox.Text = string.Empty;
            }
        }
    }
}

