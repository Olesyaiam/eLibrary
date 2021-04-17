
namespace FormsLibrary
{
    partial class FormShowAllBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.richTextBoxBooks = new System.Windows.Forms.RichTextBox();
            this.labelTextAction = new System.Windows.Forms.Label();
            this.numericUpDownActionNumber = new System.Windows.Forms.NumericUpDown();
            this.buttonAction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownActionNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(107, 26);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(415, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Вы вошли в режим вывода списка книг";
            // 
            // richTextBoxBooks
            // 
            this.richTextBoxBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxBooks.Location = new System.Drawing.Point(18, 72);
            this.richTextBoxBooks.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxBooks.Name = "richTextBoxBooks";
            this.richTextBoxBooks.ReadOnly = true;
            this.richTextBoxBooks.Size = new System.Drawing.Size(558, 284);
            this.richTextBoxBooks.TabIndex = 1;
            this.richTextBoxBooks.Text = "";
            // 
            // labelTextAction
            // 
            this.labelTextAction.AutoSize = true;
            this.labelTextAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTextAction.Location = new System.Drawing.Point(15, 382);
            this.labelTextAction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTextAction.Name = "labelTextAction";
            this.labelTextAction.Size = new System.Drawing.Size(289, 18);
            this.labelTextAction.TabIndex = 2;
            this.labelTextAction.Text = "Введите номер книги, которую хотите ...";
            // 
            // numericUpDownActionNumber
            // 
            this.numericUpDownActionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownActionNumber.Location = new System.Drawing.Point(359, 380);
            this.numericUpDownActionNumber.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownActionNumber.Name = "numericUpDownActionNumber";
            this.numericUpDownActionNumber.Size = new System.Drawing.Size(49, 24);
            this.numericUpDownActionNumber.TabIndex = 3;
            // 
            // buttonAction
            // 
            this.buttonAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAction.Location = new System.Drawing.Point(438, 377);
            this.buttonAction.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAction.Name = "buttonAction";
            this.buttonAction.Size = new System.Drawing.Size(138, 28);
            this.buttonAction.TabIndex = 4;
            this.buttonAction.Text = "Action";
            this.buttonAction.UseVisualStyleBackColor = true;
            // 
            // FormShowAllBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 429);
            this.Controls.Add(this.buttonAction);
            this.Controls.Add(this.numericUpDownActionNumber);
            this.Controls.Add(this.labelTextAction);
            this.Controls.Add(this.richTextBoxBooks);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormShowAllBooks";
            this.Text = "Список книг";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownActionNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.RichTextBox richTextBoxBooks;
        protected System.Windows.Forms.Label labelTextAction;
        protected System.Windows.Forms.NumericUpDown numericUpDownActionNumber;
        protected System.Windows.Forms.Button buttonAction;
    }
}