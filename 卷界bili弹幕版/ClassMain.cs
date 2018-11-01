using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;


namespace 卷界bili弹幕版
{
    //由Lineput2 提供的RTF辅助操控器

    public class ClassMain : BilibiliDM_PluginFramework.DMPlugin
    {
        public ClassMain()
        {
            try
            {
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                this.Connected += ClassMain_Connected;
                this.Disconnected += ClassMain_Disconnected;
                this.ReceivedDanmaku += ClassMain_ReceivedDanmaku;
                this.ReceivedRoomCount += ClassMain_ReceivedRoomCount;
                this.PluginAuth = "洛里斯杨远";
                this.PluginName = "卷界 弹幕版";
                this.PluginCont = "zoujin.admin@exlb.pw";
                this.PluginVer = "v0.1.5";
                this.PluginDesc = "弹幕版养成游戏";
                frmMain = new FrmMain();
                frmSetting = new FrmSetting(frmMain);
            }
            catch(Exception e)
            {
                LogOutput(e.ToString());
            }
        }
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string resourceName = "Newtonsoft.Json." + new AssemblyName(args.Name).Name + ".dll";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
        public FrmMain frmMain;
        public FrmSetting frmSetting;

        private void ClassMain_ReceivedRoomCount(object sender, BilibiliDM_PluginFramework.ReceivedRoomCountArgs e)
        {//收集房间总人数
            //Output("ReceivedRoomCount:" + e.UserCount.ToString());
            int newbuff = (int)Math.Sqrt(e.UserCount);
            if (frmMain.Buff != newbuff)
            {
                frmMain.Buff = newbuff;
                frmMain.OutPut("系统:全局Buff更变 当前加成" + newbuff * 5 + "%\n", Color.DarkGoldenrod);
            }
        }

        private void ClassMain_ReceivedDanmaku(object sender, BilibiliDM_PluginFramework.ReceivedDanmakuArgs e)
        {//收集弹幕的地方
            //Output("ReceivedRoomCount:" + e.Danmaku.CommentText);
            if (e.Danmaku.MsgType == BilibiliDM_PluginFramework.MsgTypeEnum.Comment || e.Danmaku.MsgType == BilibiliDM_PluginFramework.MsgTypeEnum.GiftSend)
                frmMain.Order(e.Danmaku);
            //frmMain.Invoke(frmMain.Order);
        }

        private void ClassMain_Disconnected(object sender, BilibiliDM_PluginFramework.DisconnectEvtArgs e)
        {
            LogOutput("连接已断开");
        }

        private void ClassMain_Connected(object sender, BilibiliDM_PluginFramework.ConnectedEvtArgs e)
        {
            LogOutput("已连接");
        }

        public override void Admin()
        {
            base.Admin();
            LogOutput("控制台");
            frmSetting.Show();
        }

        public override void Stop()
        {
            base.Stop();
            //請勿使用任何阻塞方法
            LogOutput("卷界已经停止运行");
        }
        public override void Start()
        {
            base.Start();
            //請勿使用任何阻塞方法
            LogOutput("卷界已启动 所在地址:" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            frmMain.Show();
            //frmMain.Show();
        }
        public void LogOutput(string Outputtext)
        {
            this.Log(Outputtext);
            this.AddDM(Outputtext, true);
        }

    }
    public class RtfHelper
    {
        public RichTextBox richText = new RichTextBox();
        public static RichTextBox staticrichText = new RichTextBox();

        public void SetRTF(RichTextBox Outrtf) => richText.Rtf = Outrtf.Rtf;
        public void OutRTF(RichTextBox Outrtf) => Outrtf.Rtf = richText.Rtf;


        public void AppendText(string text, Color fontColor, Font font)
        {
            int lastLenth = richText.TextLength;
            richText.AppendText(text);
            richText.Select(lastLenth, text.Length);
            //richText.SelectionStart = lastLenth;
            //richText.SelectionLength = text.Length;
            richText.SelectionColor = fontColor;
            richText.SelectionFont = font;

            //richText.SelectionAlignment = HorizontalAlignment.Left;

            //richText.SelectionStart = richText.TextLength;
        }
        //Output 只有静态输出，动态禁止输出OUTPUT（因为output让大大的改变了参数）
        public static void OutPut(RichTextBox Outrtf, string text, Color fontcolor, Font font)
        {
            staticrichText.Rtf = Outrtf.Rtf;
            int lastLenth = staticrichText.TextLength;
            staticrichText.AppendText(text);
            staticrichText.Select(lastLenth, text.Length);
            staticrichText.SelectionColor = fontcolor;
            staticrichText.SelectionFont = font;
            Outrtf.Rtf = staticrichText.Rtf;
        }
        public void OutPutSuper(RichTextBox Outrtf, string text, Color fontcolor, Font font)
        {
//#if !DEBUG
//            try
//            {
//#endif
                int lastLenth = richText.TextLength;
                richText.AppendText(text);
                richText.Select(lastLenth, text.Length);
                richText.SelectionColor = fontcolor;
                richText.SelectionFont = font;
                Outrtf.Rtf = richText.Rtf;                
//#if !DEBUG
//            }catch(Exception e)
//            {
                
//            }
//#endif
        }

        public static string ColorToHTML(Color Color)
        {
            string returnValue = Convert.ToInt32(Color.R * Math.Pow(256, 2) + Color.G * 256 + Color.B).ToString("x");
            int b = System.Convert.ToInt32(5 - returnValue.Length);
            for (int i = 0; i <= b; i++)
            {
                returnValue = "0" + System.Convert.ToString(returnValue);
            }
            return returnValue;
        }
        public static Color HTMLToColor(string HTML = "")
        {
            if (HTML.Length == 3)
            {
                return Color.FromArgb(Convert.ToInt32("0xff" + HTML[0] + HTML[0] + HTML[1] + HTML[1] + HTML[2] + HTML[2], 16));
            }
            else if (HTML.Length == 6)
            {
                return Color.FromArgb(Convert.ToInt32("0xff" + HTML, 16));
            }
            else
            {
                int hash = Math.Abs(HTML.GetHashCode());
                int hash1 = hash / 256;
                int hash2 = hash1 / 256;
                return Color.FromArgb(hash % 256, hash1 % 256, hash2 % 256);
            }
        }

        public static FontStyle BoolToFontStyle(bool Bsty, bool Delsty, bool Usty, bool Isty)
        {
            FontStyle sty = System.Drawing.FontStyle.Regular;
            if (Bsty)
            {
                sty += 1;
            }
            if (Delsty)
            {
                sty += 8;
            }
            if (Usty)
            {
                sty += 4;
            }
            if (Isty)
            {
                sty += 2;
            }
            return sty;
        }
        public static void FontStyleToBool(FontStyle FontStyle, out bool Bsty, out bool Delsty, out bool Usty, out bool Isty)
        {
            Bsty = false;
            Delsty = false;
            Usty = false;
            Isty = false;
            int tmp = Convert.ToInt32(FontStyle);
            if (tmp >= 8)
            {
                tmp -= 8;
                Delsty = true;
            }
            if (tmp >= 4)
            {
                tmp -= 4;
                Usty = true;
            }
            if (tmp >= 2)
            {
                tmp -= 2;
                Isty = true;
            }
            if (tmp == 1)
            {
                Bsty = true;
            }
        }



    }
}
