using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace 卷界bili弹幕版
{
    public partial class FrmMain : Form
    {
        public RtfHelper TextBox1HP = new RtfHelper();
        public List<User> users = new List<User>();
        public List<int> UserOnline = new List<int>();//用来快速判断 用户是否签到
        public Random rnd = new Random();
        public int Buff = 0;//全局BUF 获得了 经验值等奖励 根据在线人数获得
        public FrmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//粗暴的干掉线程安全

            TextBox1.BackColor = Properties.Settings.Default.BackColor;
            labelphb.BackColor = Properties.Settings.Default.BackColor;

            TextBox1.Font = Properties.Settings.Default.MainFont;
            if (Properties.Settings.Default.IsTranspare)
                TransparencyKey = TextBox1.BackColor;

            TXTOut.Add("");//默认有首行且为空


            TextBox1HP.SetRTF(TextBox1);
            OutPut("卷界欢迎您!\n当前版本B16\n使用教程:http://www.exlb.org/rollworlddm/\nBug反馈:zoujin.admin@exlb.pw\n");
            timeRels = DateTime.Now.Day;
            LoadGame();
            RelsPHB();
        }
        //
        public void RelsPHB()
        {
            StringBuilder sb = new StringBuilder();
            var sort = users.OrderBy(x => x.TotalFight()).Reverse();
            int si = 1;
            sb.AppendLine("战力排行榜");
            foreach (User ui in sort)
            {
                sb.AppendLine(($"第{si} {ui.Name} " + ui.TotalFight()));
                if (si++ >= 5)
                    break;
            }
            sb.AppendLine("\n金币排行榜");
            sort = users.OrderBy(x => x.Money).Reverse();
            si = 1;
            foreach (User ui in sort)
            {
                sb.AppendLine($"第{si} {ui.Name} " + ui.Money);
                if (si++ >= 5)
                    break;
            }
            labelphb.Text = sb.ToString();
        }


        #region Output
        //output需要使用记录
        List<string> TXTOut = new List<string>();
        //Environment.SpecialFolder.ApplicationData + @"\LBSoft\RWdm\output.txt"
        //public bool IsTXTOut = false;
        public void TXTOutput(string text)
        {
            AddInTXT(text);
            if (TXTOut.Count > Properties.Settings.Default.TxtLine + 1)
            {
                for (int i = TXTOut.Count - Properties.Settings.Default.TxtLine; i > 1; i--)
                {
                    TXTOut.RemoveAt(0);
                }
            }
            //开始保存文件
            try//如果文件被堵就等下次再写
            {
                FileInfo output = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LBSoft\RWdm\output.txt");
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < TXTOut.Count - 1; i++)
                {
                    sb.Append(TXTOut[i] + "\r\n");
                }
                sb.Append(TXTOut[TXTOut.Count - 1]);
                byte[] wwrite = Encoding.UTF8.GetBytes(sb.ToString());
                FileStream fs = output.Create();
                fs.Write(wwrite, 0, wwrite.Length);
                fs.Close();
            }
            catch
            {

            }
        }
        public void AddInTXT(string text)
        {
            int oldlen = TXTOut.Count - 1;//记录现在的TXTOUT的长度
            if (!text.Contains("\n"))//如果没有换行
            {
                TXTOut[TXTOut.Count - 1] += text;
            }
            else
            {
                string[] tmps = text.Split('\n');
                TXTOut[TXTOut.Count - 1] += tmps[0];
                for (int i = 1; i < tmps.Length; i++)
                {
                    TXTOut.Add(tmps[i]);
                }
            }
            string tmp;
            for (int i = TXTOut.Count - 1; i < TXTOut.Count; i++)
            {
                if (System.Text.Encoding.ASCII.GetBytes(TXTOut[i]).Length > Properties.Settings.Default.Txtwide)
                {
                    tmp = TXTOut[i];
                    TXTOut[i] = getStr(tmp, Properties.Settings.Default.Txtwide);
                    TXTOut.Insert(i + 1, tmp.Substring(TXTOut[i].Length));
                }
            }
        }
        /// <summary>
        /// 截取文本，区分中英文字符，中文算两个长度，英文算一个长度，截取后增加...，占3个长度(包括在限制长度内)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="l">不小于3</param>
        /// <returns></returns>
        public static string getStr(string s, int l)
        {
            string temp = s.Substring(0, (s.Length < l + 1) ? s.Length : l + 1);
            byte[] encodedBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(temp);

            string outputStr = "";
            int count = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if ((int)encodedBytes[i] == 63)
                    count += 2;
                else
                    count += 1;

                if (count <= l)
                    outputStr += temp.Substring(i, 1);
                else if (count > l)
                    break;
            }

            if (count <= l)
            {
                outputStr = temp;
            }
            return outputStr;
        }
        public void OutPut(string text, Color color, Font font)
        {
            TextBox1HP.OutPutSuper(TextBox1, text, color, font);
            TextBox1.Select(TextBox1.TextLength, 0);
            TextBox1.ScrollToCaret();
            if (Properties.Settings.Default.IsTXTOut)
                TXTOutput(text);
        }
        public void OutPut(string text, Color color)
        {
            OutPut(text, color, TextBox1.Font);
        }
        public void OutPutAppend(string text, Color color, Font font)
        {
            TextBox1HP.AppendText(text, color, font);
            if (Properties.Settings.Default.IsTXTOut)
                AddInTXT(text);
        }
        public void OutPut(string text)
        {
            OutPut(text, Color.Black, TextBox1.Font);
        }
        #endregion
        public void Order(BilibiliDM_PluginFramework.DanmakuModel model)
        {
            if (users.FirstOrDefault(x => x.Uid == model.UserID) != null)//如果是注册用户
            {
                User usr = users.FirstOrDefault(x => x.Uid == model.UserID);
                if (!usr.Update)
                {
                    usr.VipLv = 1 + Convert.ToInt32(model.isVIP) + (Convert.ToInt32(model.isAdmin) + model.UserGuardLevel) * 2;
                    usr.Name = model.UserName;
                    usr.Update = true;
                }
                if (model.MsgType == BilibiliDM_PluginFramework.MsgTypeEnum.GiftSend)
                {//礼物：充值内容
                    if (model.GiftName == "辣条")
                    {
                        usr.Money += 5 * model.GiftCount;
                        OutPut($"{usr.Name}:使用 {model.GiftName}*{model.GiftCount} 获得了 {5 * model.GiftCount} 金钱\n");
                    }
                    else
                    {
                        JObject staff = JObject.Parse(model.RawData);
                        int gifmon = staff["data"]["price"].ToObject<int>();
                        usr.Money += (int)(gifmon * 0.1 * model.GiftCount);//加钱      
                        OutPut($"{usr.Name}:使用 {model.GiftName}*{model.GiftCount} 获得了 {(int)(gifmon * 0.1 * model.GiftCount)} 金钱\n");
                    }


                }
                else if (model.CommentText.Contains("#"))
                {//简单判断是否使用了指令
                    if (UserCanOrder(usr))
                    {
                        string[] order = model.CommentText.Trim().Split(' ');
                        switch (order[0])
                        {
                            case "#qd":
                            case "#签到":
                                if (UserOnline.Contains(model.UserID))//如果已经签到
                                {
                                    OutPut(model.UserName + ":您今天已经签到过了，请明天再来\n");
                                }
                                else
                                {
                                    int gtmoney = rnd.Next(15, (int)(30 * usr.VipBuff() * Buffef()));
                                    UserOnline.Add(model.UserID);
                                    OutPut(model.UserName + ":签到成功 获得了" + gtmoney + "金钱 宠物体力已经恢复\n");
                                    usr.Money += gtmoney;
                                }
                                break;
                            case "#dz":
                            case "#打坐":
                                int cisu = 1;//打坐次数 
                                if (order.Length == 2 && IsUnsignInt(order[1]))
                                {
                                    cisu = Convert.ToInt32(order[1]);
                                }
                                if (usr.Action >= cisu)//判断是否有足够的行动力
                                {
                                    int gtexp;
                                    gtexp = (int)((rnd.Next(9, 32) * cisu + 1) * 0.1 * Buffef() * usr.VipBuff());
                                    usr.Action -= cisu;
                                    usr.Exp += gtexp;
                                    OutPut(model.UserName + ":打坐 消耗" + cisu + "点行动值 获得了" + gtexp + "点经验值\n");
                                }
                                else
                                {
                                    OutPut(model.UserName + ":打坐 让你的宠物休息会吧！行动力不足!\n");
                                }
                                break;
                            case "#xx":
                            case "#信息":
                                OutPutAppend(model.UserName + ":金币", Color.Black, TextBox1.Font);
                                OutPutAppend(usr.Money.ToString(), Color.Blue, new Font(TextBox1.Font, FontStyle.Bold));
                                OutPutAppend(" Lv ", Color.Black, TextBox1.Font);
                                OutPutAppend(usr.Lv.ToString(), Color.Blue, new Font(TextBox1.Font, FontStyle.Bold));
                                OutPutAppend(" (" + intToRoman(Convert.ToInt32(Math.Sqrt(usr.Lv))) + ')' + " Exp ", Color.Black, TextBox1.Font);
                                OutPutAppend(usr.Exp.ToString(), Color.Blue, new Font(TextBox1.Font, FontStyle.Bold));
                                OutPutAppend("/" + usr.Lv * 2 + " HP/攻/防 ", Color.Black, TextBox1.Font);
                                OutPutAppend(usr.HPMax().ToString() + '/' + usr.Attact() + '/' + usr.Defense(), Color.Blue, new Font(TextBox1.Font, FontStyle.Bold));
                                OutPutAppend(" 行动值 ", Color.Black, TextBox1.Font);
                                OutPut(usr.Action.ToString() + '/' + usr.ActionMax() + '\n', Color.Blue, new Font(TextBox1.Font, FontStyle.Bold));
                                break;
                            case "#xj":
                            case "#献祭":
                                if (order.Length == 2 && IsUnsignInt(order[1]))
                                {
                                    cisu = Convert.ToInt32(order[1]);
                                    if (cisu < 25 || cisu > 250)
                                    {
                                        OutPut(model.UserName + ":献祭最低25金币,最高250金币\n");
                                    }
                                    else if (usr.Money >= cisu)//判断是否有足够的金钱
                                    {
                                        usr.Money -= cisu;
                                        OutPut(model.UserName + ":献祭了" + cisu + "金币 " + RndPrice(usr, (int)(Math.Pow(cisu / 5, 1.1) * (1 + (usr.Lv + Buff) * 0.05) * usr.VipBuff())) + '\n');
                                    }
                                    else
                                    {
                                        OutPut(model.UserName + ":没有足够多的金币进行献祭\n");
                                    }
                                }
                                else
                                {
                                    OutPut(model.UserName + ":错误的献祭金币数目\n");
                                }
                                break;
                            case "#sj":
                            case "#升级":
                                if (order.Length == 5 && IsUnsignInt(order[1]) && IsUnsignInt(order[2]) && IsUnsignInt(order[3]) && IsUnsignInt(order[4]))
                                {
                                    if (usr.Lv * 2 <= usr.Exp)
                                    {
                                        int AT, K, HP, F;
                                        string Tmp = "";
                                        AT = Convert.ToInt32(order[1]);
                                        HP = Convert.ToInt32(order[2]);
                                        K = Convert.ToInt32(order[3]);
                                        F = Convert.ToInt32(order[4]);
                                        if (usr.Lv == AT + K + HP + F)
                                        {
                                            if (HP != 0)
                                            {
                                                Tmp += HP * 2.5 + "HP上限, ";
                                                usr.HPMaxLv += HP;
                                            }
                                            if (K != 0)
                                            {
                                                Tmp += (int)(K * 1.8) * 0.25 + "攻击力, ";
                                                usr.AttactLv += K;
                                            }
                                            if (F != 0)
                                            {
                                                Tmp += (int)(F * 1.6) * 0.25 + "防御力, ";
                                                usr.DefenseLv += F;
                                            }
                                            if (AT != 0)
                                            {
                                                Tmp += (AT * 3) * 0.25 + "行动值上限, ";
                                                usr.ActionMaxLv += AT;
                                            }
                                            usr.Lv += 1;
                                            usr.Exp -= usr.Lv * 2;
                                            usr.Action = (int)usr.ActionMax();
                                            OutPut(model.UserName + ":恭喜升级至 Lv" + usr.Lv + " 获得了 " + Tmp + "行动值已经恢复\n");
                                        }
                                        else
                                        {
                                            OutPut(model.UserName + ":升级失败 您拥有" + usr.Lv + "点分配,但您分配了" + (AT + K + HP + F) + "点\n");
                                        }
                                    }
                                    else
                                    {
                                        OutPut(model.UserName + ":升级失败 经验值不足 " + usr.Exp + "/" + usr.Lv * 2 + "\n");
                                    }
                                }
                                else
                                {
                                    OutPut(model.UserName + ":升级失败 错误的升级参数\n");
                                }
                                break;
                            case "#sd":
                            case "#商店":
                                if (order.Length == 3 && IsUnsignInt(order[1]) && IsUnsignInt(order[2]))
                                {
                                    cisu = Convert.ToInt32(order[2]);
                                    switch (Convert.ToInt32(order[1]))
                                    {
                                        case 2:
                                            if (usr.Money >= cisu * 5)//判断是否有足够的金钱 （*5是物品id2的物品价格）
                                            {
                                                usr.Money -= cisu * 5;//消耗金钱
                                                usr.Action += cisu * 4;//商品内容 行动值*4
                                                OutPut(model.UserName + $":购买了'行动值*4'*{cisu} 花费{ cisu * 5 }金币 谢谢惠顾 \n");
                                            }
                                            else
                                            {
                                                OutPut(model.UserName + ":没有足够多的金币购买'行动值*4'\n");
                                            }
                                            break;
                                        default:
                                            OutPut(model.UserName + ":商店 暂时没有这个商品");
                                            break;
                                    }
                                }
                                else
                                {
                                    OutPut(model.UserName + ":商店 错误的商店id和数量");
                                }
                                break;
                            case "#tz":
                            case "#挑战":
                                if (order.Length == 2)
                                {
                                    if (usr.Action > usr.Lv)
                                    {
                                        //usr.Action -= usr.Lv;
                                        OutPut(model.UserName + ":由于挑战模式还在测试中,将不会消耗经历值\n");
                                        User FitUr;
                                        if (IsUnsignInt(order[1]))
                                        {
                                            FitUr = users.FirstOrDefault(x => x.Uid == (Convert.ToInt32(order[1])));
                                        }
                                        else
                                        {
                                            FitUr = users.FirstOrDefault(x => x.Name == order[1]);
                                        }
                                        if (FitUr == null)
                                        {
                                            break;
                                        }
                                        OutPut(model.UserName + $":挑战{order[1]}战斗开始\n");
                                        Fight(usr, FitUr);
                                    }
                                    else
                                    {
                                        OutPut(model.UserName + ":挑战 让你的宠物休息会吧！行动力不足!\n");
                                    }
                                }
                                else
                                {
                                    OutPut(model.UserName + ":挑战 错误的挑战参数");
                                }
                                break;
                            //case "#tx":
                            //case "#探险":
                            //    if (usr.Action > usr.Lv)
                            //    {
                            //        //usr.Action -= usr.Lv;
                            //        int dlv, dhp, dk, df;    //dluck
                            //        string dname;
                            //        dlv = 1 + rnd.Next((int)(usr.Lv * 0.8), (int)(usr.Lv * 1.3));
                            //        OutPut(model.UserName + ":由于探险模式还在测试中,将不会消耗经历值\n");
                            //        switch (rnd.Next(0))
                            //        {
                            //            default:
                            //                dname = "怪物";
                            //                dhp = rnd.Next((int)(dlv * 0.5) + 2, (int)(dlv) + 2);
                            //                dk = rnd.Next((int)(dlv * 0.2) + 2, (int)(dlv * 0.4) + 2);
                            //                df = rnd.Next((int)(dlv * 0.1) + 2, (int)(dlv * 0.2) + 2);
                            //                break;
                            //        }

                            //        //                                Case 1

                            //        //        dname = "怪物"

                            //        //        dhp = int((dlv * (rnd + 0.5)) ^ 1.8 + 5)

                            //        //        dk = int((dlv * (rnd * 0.4 + 0.5)) ^ 1.5 * 10) * 0.1

                            //        //        df = int((dlv * (rnd * 0.2 + 0.25)) ^ 1.4 * 10) * 0.1

                            //        //    Case 2

                            //        //        dname = "强盗"

                            //        //        dhp = int((dlv * (rnd * 0.5 + 0.5)) ^ 1.8 + 5)

                            //        //        dk = int((dlv * (rnd * 0.75 + 0.5)) ^ 1.5 * 10) * 0.1

                            //        //        df = int((dlv * (rnd * 0.25 + 0.25)) ^ 1.4 * 10) * 0.1

                            //        //    Case 3

                            //        //        dname = "森之妖精"

                            //        //        dhp = int((dlv * (rnd + 1.5)) ^ 1.8 + 5)

                            //        //        dk = int((dlv * (rnd * 0.4 + 0.5)) ^ 1.5 * 10) * 0.1

                            //        //        df = int((dlv * (rnd * 0.2 + 0.25)) ^ 1.4 * 10) * 0.1

                            //        //    Case 4

                            //        //        dname = "壬辰酱"

                            //        //        dhp = int((dlv * (rnd * 0.5 + 0.75)) ^ 1.8 + 5)

                            //        //        dk = int((dlv * (rnd * 0.5 + 0.75)) ^ 1.5 * 10) * 0.1

                            //        //        df = int((dlv * (rnd * 0.5 + 0.5)) ^ 1.4 * 10) * 0.1

                            //        //    Case 5

                            //        //        dlv = int(dlv * 1.2)

                            //        //        dname = "王司徒"

                            //        //        dhp = int((dlv * (rnd * 0.5 + 0.75)) ^ 1.8 + 5)

                            //        //        dk = int((dlv * (rnd * 0.5 + 0.6)) ^ 1.5 * 10) * 0.1

                            //        //        df = int((dlv * (rnd * 0.4 + 0.25)) ^ 1.4 * 10) * 0.1

                            //        //    Case 6

                            //        //        dlv = int(dlv * 1.2)

                            //        //        dname = "河蟹神兽"

                            //        //        dhp = int((dlv * (rnd * 0.5 + 0.5)) ^ 1.8 + 5)

                            //        //        dk = int((dlv * (rnd * 0.5 + 0.5)) ^ 1.5 * 10) * 0.1

                            //        //        df = int((dlv * (rnd * 0.5 + 0.5)) ^ 1.4 * 10) * 0.1

                            //        //    Case Else

                            //        //        '直接结算探险结束

                            //        //        BBS.Alert"探险完成，" & RndPrice(int(1 + Interest(4) * 0.25) * 0.5),"?"

                            //        //        Exit Sub

                            //        //End Select
                            //        switch ((int)(Math.Sqrt(dlv) * 0.5))
                            //        {
                            //            case 0:
                            //                dname = "实习" + dname;
                            //                break;
                            //            case 1:
                            //                dname = "试用" + dname;
                            //                break;
                            //            case 2:
                            //                dname = "助理" + dname;
                            //                break;
                            //            case 3:
                            //                dname = "白银" + dname;
                            //                break;
                            //            case 4:
                            //                dname = "黄金" + dname;
                            //                break;
                            //            case 5:
                            //                dname = "白金" + dname;
                            //                break;
                            //            case 6:
                            //                dname = "钻石" + dname;
                            //                break;
                            //            default:
                            //                dname = intToRoman((int)(Math.Sqrt(dlv) * 0.5)) + "级" + dname;
                            //                break;
                            //        }
                            //        OutPut(model.UserName + $":探险 偶遇{dname} 战斗开始\n");
                            //        Fight(usr, new User(dname, dlv, dhp, df, dk));
                            //    }
                            //    else
                            //    {
                            //        OutPut(model.UserName + ":探险 让你的宠物休息会吧！行动力不足!\n");
                            //    }
                            //    break;
                            default:
                                OutPut(model.UserName + ":错误的指令参数,找不到指令'" + order[0] + "'\n");
                                break;
                        }
                    }
                    else if (usr.OrderMax == 101)
                    {
                        OutPut(model.UserName + ":今日指令次数已经用完\n", Color.Orange);
                    }
                }

            }
            else
            {//如果没有注册
                if (model.CommentText == "#注册")
                {
                    users.Add(new User(model.UserID));
                    OutPut(model.UserName + ":注册成功\n");
                }

            }
            //准备做个自动回复
        }

        public double TrueValue(double value)//增加战斗随机性的数值
        {
            return rnd.Next((int)(value * 9), (int)(value * 11)) * 0.1;
        }

        public bool UserCanOrder(User usr)
        {
            usr.OrderMax++;
            return usr.OrderMax < Properties.Settings.Default.CanUserOrderMax;
        }
        public int Fight(User usr1, User usr2)//战斗 返回的是玩家1的得分，通过得分判断获得礼包
        {
            double[] USK = new double[2];//玩家造成的伤害
            int[] USpesn = new int[2];//对方造成的伤害所占hp百分比
            USK[0] = TrueValue(usr1.Attact()) - TrueValue(usr2.Defense());//玩家1造成的伤害=攻击力-敌方防御力
            USK[1] = TrueValue(usr2.Attact()) - TrueValue(usr1.Defense());//玩家2造成的伤害=攻击力-敌方防御力

            if (USK[0] < 0)
                USK[0] = 0;
            if (USK[1] < 0)
                USK[1] = 0;

            USpesn[0] = (int)(USK[0] / usr2.HPMax() * 1000);
            USpesn[1] = (int)(USK[1] / usr1.HPMax() * 1000);

            OutPutAppend($"{usr1.Name}对{usr2.Name}造成", Color.Black, TextBox1.Font);
            OutPutAppend($"{USK[0]}({USpesn[0] * 0.1}%)", Color.Red, new Font(TextBox1.Font, FontStyle.Bold));
            OutPutAppend($"的伤害，{usr2.Name}对{usr1.Name}造成", Color.Black, TextBox1.Font);
            OutPutAppend($"{USK[1]}({USpesn[1] * 0.1}%)", Color.Red, new Font(TextBox1.Font, FontStyle.Bold));
            OutPutAppend($"的伤害\n战斗结束:", Color.Black, TextBox1.Font);

            //战斗评分
            int finsco = 5;
            int hhs;//所用回合数
            bool IsWiner = false;//赢了没

            if (USpesn[0] < USpesn[1])
            {//usr1输了
                finsco--;//输了减1分
                OutPutAppend(usr2.Name, Color.Goldenrod, new Font(TextBox1.Font, FontStyle.Bold));
                OutPutAppend("获得最终胜利 战斗评分:", Color.Black, TextBox1.Font);
                hhs = Convert.ToInt32(1000 / USpesn[1]);
            }
            else
            {//usr1赢了
                finsco += 2;//赢了+2分
                IsWiner = true;
                OutPutAppend(usr1.Name, Color.Goldenrod, new Font(TextBox1.Font, FontStyle.Bold));
                OutPutAppend("获得最终胜利 战斗评分:", Color.Black, TextBox1.Font);
                hhs = Convert.ToInt32(1000 / USpesn[0]);
            }

            int fsc = usr2.TotalFight() - usr1.TotalFight();//计算分数差

            if (fsc < 0)//顺丰
            {
                fsc = Convert.ToInt32(Math.Pow(-fsc, 0.25));//顺丰分数差为负分
                if (IsWiner)
                    finsco -= fsc;//如果顺丰胜利，减少点分数
                else
                    finsco -= fsc * 2;//如果顺丰失败，减少更多分数
            }
            else//逆风
            {
                fsc = Convert.ToInt32(Math.Pow(fsc, 0.25));//逆风+胜利 分数差为加分

                if (IsWiner)
                    finsco += fsc;//逆风胜利+fsc
                                  //失败不加分

                if (hhs > 10)
                    finsco += 2;//撑了很多回合
                else if (hhs < 4)
                    finsco -= 2;//秒杀
            }

            if (finsco < 0)
                finsco = 0;//保底

            OutPut(finsco.ToString() + "\n", Color.Red, new Font(TextBox1.Font, FontStyle.Bold));
            return finsco;
        }



        public string RndPrice(User usr, int Cn)//礼包
        {
            int THP, ARMB, TEXP, TK, TF, TAct, TActMax;
            string DZLB, OString;
            switch ((int)Math.Sqrt(Cn))
            {
                case 1:
                    DZLB = "小礼包";
                    break;
                case 2:
                    DZLB = "中礼包";
                    break;
                case 3:
                    DZLB = "大礼包";
                    break;
                case 4:
                    DZLB = "白银礼包";
                    break;
                case 5:
                    DZLB = "黄金礼包";
                    break;
                case 6:
                    DZLB = "钻石礼包";
                    break;
                case 7:
                    DZLB = "大侠礼包";
                    break;
                case 8:
                    DZLB = "掌门礼包";
                    break;
                case 9:
                    DZLB = "宗师礼包";
                    break;
                default:
                    DZLB = intToRoman((int)Math.Sqrt(Cn)) + "礼包";
                    break;
            }
            DZLB = '\'' + DZLB + '\'';

            THP = rnd.Next(0, (int)(0.5 * Cn));
            if (rnd.Next(21) < 8)
            {
                THP = 0;
            }
            TK = rnd.Next(0, (int)(0.4 * Cn));
            if (rnd.Next(20) < 8)
            {
                TK = 0;
            }
            TF = rnd.Next(0, (int)(0.4 * Cn));
            if (rnd.Next(19) < 8)
            {
                TF = 0;
            }
            TActMax = rnd.Next(0, (int)(0.4 * Cn));
            if (rnd.Next(18) < 8)
            {
                TActMax = 0;
            }
            TAct = rnd.Next(0, Cn);
            if (rnd.Next(22) < 8)
            {
                TAct = 0;
            }
            TEXP = rnd.Next(0, (int)(0.8 * Cn));
            if (rnd.Next(25) < 8)
            {
                TEXP = 0;
            }
            ARMB = rnd.Next(0, (int)1.5 * Cn);
            if (rnd.Next(25) < 8)
            {
                ARMB = 0;
            }


            OString = "";
            if (THP != 0)
            {
                OString += THP * 2.5 + " HP上限, ";
                usr.HPMaxLv += THP;
            }
            if (TEXP != 0)
            {
                OString += TEXP + "卷界经验值, ";
                usr.Exp += TEXP;
            }
            if (TK != 0)
            {
                OString += (int)(TK * 1.8) * 0.25 + "攻击力, ";
                usr.AttactLv += TK;
            }
            if (TF != 0)
            {
                OString += (int)(TF * 1.6) * 0.25 + "防御力, ";
                usr.DefenseLv += TF;
            }
            if (TAct != 0)
            {
                OString += TAct + "个行动值, ";
                usr.Action += TAct;
            }
            if (TActMax != 0)
            {
                OString += (TActMax * 3) * 0.25 + "行动值上限, ";
                usr.ActionMaxLv += TActMax;
            }
            if (ARMB != 0)
            {
                OString += ARMB + "金币, ";
                usr.Money += ARMB;
            }

            if (OString == "")
            {
                OString = "什么都没有获得";
            }
            else
            {
                OString = "获得了" + DZLB + ": " + OString;
            }


            return OString;
        }
        public double Buffef()
        {
            return 1 + Buff * 0.05;
        }
        int timeRels;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //每? 0.1小时进行一次存档备份
            SaveGame();
            //清空文本//防止输出文本超过上限导致溢出
            if (TextBox1.TextLength >= 214748364)
            {
                TextBox1.Text = TextBox1.Text.Substring(214746364);
                TextBox1HP.SetRTF(TextBox1);
                TextBox1.Select(TextBox1.TextLength, 0);
                TextBox1.ScrollToCaret();
            }

            //判断有没有过一天
            if (timeRels != DateTime.Now.Day)
            {
                RelsUser();
            }
        }
        public void SaveGame()//保存用户数据
        {//Environment.CurrentDirectory 
#if !DEBUG
            int Reload = 0;
        RES:
            try
            {
#endif
            DirectoryInfo SavePath = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LBSoft\RWdm");
            if (!SavePath.Exists)
            {
                SavePath.Create();
            }
            FileInfo SaveFile = new FileInfo(SavePath.FullName + @"\gsave.rwd");
            FileStream fs = SaveFile.Create();
            StringBuilder sb = new StringBuilder();
            foreach (User usr in users)
            {
                sb.Append(usr.Data() + "\r\n");
            }
            byte[] wwrite = Encoding.UTF8.GetBytes(sb.ToString());
            fs.Write(wwrite, 0, wwrite.Length);
            fs.Close();
#if !DEBUG
            }
            catch (Exception e)
            {
                if (Reload >= 10)
                {
                    OutPut(e.ToString(), Color.Red);
                }
                Reload += 1;
                goto RES;
            }
#endif
        }
        public void LoadGame()
        {//清理旧数据
            users.Clear();
            //UserOnline.Clear();
            FileInfo SaveFile = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LBSoft\RWdm\gsave.rwd");
            if (!SaveFile.Exists)
            {
                return;
            }
            FileStream fs = SaveFile.OpenRead();
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            string[] readth = Encoding.UTF8.GetString(buffer).Replace("\r", "").Trim('\n').Split('\n');
            if (readth[0] == "")
                return;
            foreach (string rt in readth)
            {
                users.Add(new User(rt));
            }
            OutPut($"存档加载完成{readth.Length}\n");
        }

        public void RelsUser()
        {
            foreach (User usr in users)
            {
                usr.OrderMax = 0;
            }
        }

        //一些辅助的方法
        public static bool IsNumeric(string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$");
        }
        public static bool IsInt(string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^-?[1-9]\d*|0$");
        }
        public static bool IsUnsignInt(string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^[1-9]\d*|0$"); ;
        }
        public string intToRoman(int n)
        {

            string[] roman = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            string o;
            int i = 0;
            int[] arabic = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            o = "";
            while (n > 0)
            {
                while (n >= arabic[i])
                {
                    n = n - arabic[i];
                    o = o + roman[i];
                }
                i = i + 1;
            }
            return o;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveGame();
            Properties.Settings.Default.Save();
            switch (MessageBox.Show("是 - 退出\n否 - 进入隐藏模式\n取消 - 取消操作", "确认退出?或进入隐藏模式", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    MessageBox.Show("进入假退出状态");
                    TextBox1HP.richText.Text = "";
                    OutPut("卷界欢迎您!\n使用教程:http://www.exlb.org/rollworlddm/\n");
                    this.Hide();
                    e.Cancel = true;
                    break;
                case DialogResult.No:
                    this.Hide();
                    e.Cancel = true;
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }

    public class User
    {
        //用户基础信息(需要保存的)
        public int Uid;
        public int Money;
        public int Exp;
        public int HPMaxLv;
        public int DefenseLv;
        public int Lv;
        public int AttactLv;
        public int Action;
        public int ActionMaxLv;

        //用户高级信息(例如违规.封禁等)
        public int OrderMax = 0;//用户最大可以使用命令条数(默认100/天)//清除方法:重启游戏 timer刷新

        public bool Update = false;//判断用户是否更新了个人数据
        public int VipLv = 1;//用户vip等级越高，权限越多
        public string Name = "";//名字为显示用


        //方法
        #region 数据保存
        public User(int uid)//注册
        {
            Uid = uid;
            Name = Uid.ToString().Substring(0, (Uid.ToString().Length > 4) ? 4 : Uid.ToString().Length) + "*** (未登录)";
            Money = 100;
            Exp = 0;
            Lv = 1;
            HPMaxLv = 2;//2*10 *0.25
            DefenseLv = 0; //2*1.6 *0.25
            AttactLv = 3;//3*1.8 *0.25
            ActionMaxLv = 3;//3*1.5 *0.25
            Action = Convert.ToInt32(ActionMax());
        }
        //public User(int uid, int money, int exp, int lv, int hPMaxLv, int defenseLv, int attactLv, int actionMaxLv)//加载数据//注:直接给体力
        //{
        //    Uid = uid;
        //    Money = money;
        //    Exp = exp;
        //    Lv = lv;
        //    HPMaxLv = hPMaxLv;//2*10 *0.25
        //    DefenseLv = defenseLv; //2*1.6 *0.25
        //    AttactLv = attactLv;//3*1.8 *0.25
        //    ActionMaxLv = actionMaxLv;//3*1.5 *0.25
        //    Action = Convert.ToInt32(ActionMax());
        //}
        public User(string name, int lv, int hPMaxLv, int defenseLv, int attactLv)//创建一次性用的战斗角色
        {
            Name = name;
            Lv = lv;
            HPMaxLv = hPMaxLv;//2*10 *0.25
            DefenseLv = defenseLv; //2*1.6 *0.25
            AttactLv = attactLv;//3*1.8 *0.25
        }
        public User(string Loadinfo)//加载数据//注:直接给体力
        {
            string[] tmps = Loadinfo.Split('|');
            Uid = Convert.ToInt32(tmps[0]);
            Name = tmps[0].Substring(0, (tmps[0].Length > 4) ? 4 : tmps[0].Length) + "*** (未登录)";
            Money = Convert.ToInt32(tmps[1]);
            Exp = Convert.ToInt32(tmps[2]);
            Lv = Convert.ToInt32(tmps[3]);
            HPMaxLv = Convert.ToInt32(tmps[4]);//2*10 *0.25
            DefenseLv = Convert.ToInt32(tmps[5]); //2*1.6 *0.25
            AttactLv = Convert.ToInt32(tmps[6]);//3*1.8 *0.25
            ActionMaxLv = Convert.ToInt32(tmps[7]);//3*1.5 *0.25
            Action = Convert.ToInt32(ActionMax());
        }
        public string Data()//输出存档信息
        {
            return Uid + "|" + Money + "|" + Exp + "|" + Lv + "|" + HPMaxLv + "|" + DefenseLv + "|" + AttactLv + "|" + ActionMaxLv;
        }
        #endregion
        #region 转换
        public double HPMax()
        {
            return HPMaxLv * 2.5;
        }
        public double Defense()
        {
            return (int)(DefenseLv * 1.6) * 0.25;
        }
        public double Attact()
        {
            return (int)(AttactLv * 1.8) * 0.25;
        }
        public double ActionMax()
        {//双倍经验值上限，主要用于吸引用户
            return (ActionMaxLv * 3) * 0.25;
        }
        #endregion

        public double VipBuff()//VIP会获得BUFF
        {
            return (3 + VipLv) * 0.25;
        }
        public int TotalFight()//计算综合实力
        {
            return (int)(Math.Pow(HPMaxLv + DefenseLv + AttactLv, 1.1) * 10);
        }

    }
}
