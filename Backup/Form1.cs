using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
// Download by http://www.codefans.net
using System.Data;
namespace MyFile
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "请输入文字信息：";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(184, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "保存为WORD文件格式";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(8, 32);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(320, 176);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(336, 214);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "演示操作WORD文件";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{//保存为WORD文件
			if(this.richTextBox1.Text=="")
				return;
			if(this.saveFileDialog1.ShowDialog()==DialogResult.Cancel)
				return;
			string FileName=this.saveFileDialog1.FileName;
			if(FileName.Length<1)
				return;
			FileName+=".doc";
			try
			{
				Word.ApplicationClass MyWord=new Word.ApplicationClass(); 
				Word.Document MyDoc;				
				Object Nothing=System.Reflection.Missing.Value; 
				MyDoc=MyWord.Documents.Add(ref Nothing,ref Nothing,ref Nothing,ref Nothing); 
				MyDoc.Paragraphs.Last.Range.Text=this.richTextBox1.Text; 
				object MyFileName=FileName;
				//将WordDoc文档对象的内容保存为DOC文档 
				MyDoc.SaveAs(ref MyFileName,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing,ref Nothing); 
				//关闭WordDoc文档对象 
				MyDoc.Close(ref Nothing, ref Nothing, ref Nothing); 
				//关闭WordApp组件对象 
				MyWord.Quit(ref Nothing, ref Nothing, ref Nothing); 		
				MessageBox.Show("WORD文件保存成功","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch(Exception Err)
			{
				MessageBox.Show("WORD文件保存操作失败！"+Err.Message,"信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
	}
}
