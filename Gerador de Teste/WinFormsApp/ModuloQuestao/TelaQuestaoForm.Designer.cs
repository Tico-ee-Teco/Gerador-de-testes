namespace WinFormsApp.ModuloQuestao
{
    partial class TelaQuestaoForm
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
            label1 = new Label();
            cmbMateria = new ComboBox();
            label2 = new Label();
            txtEnunciado = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            btnAdicionarQuestao = new Button();
            groupBox1 = new GroupBox();
            btnRemoverAlternativa = new Button();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 48);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Matéria:";
            // 
            // cmbMateria
            // 
            cmbMateria.FormattingEnabled = true;
            cmbMateria.Location = new Point(101, 45);
            cmbMateria.Name = "cmbMateria";
            cmbMateria.Size = new Size(151, 28);
            cmbMateria.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 119);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 2;
            label2.Text = "Enunciado:";
            // 
            // txtEnunciado
            // 
            txtEnunciado.Location = new Point(101, 101);
            txtEnunciado.Multiline = true;
            txtEnunciado.Name = "txtEnunciado";
            txtEnunciado.PlaceholderText = "Quanto é 2 + 2?";
            txtEnunciado.Size = new Size(316, 60);
            txtEnunciado.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(101, 185);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 48);
            textBox1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 195);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 4;
            label3.Text = "Resposta:";
            // 
            // btnAdicionarQuestao
            // 
            btnAdicionarQuestao.Location = new Point(289, 185);
            btnAdicionarQuestao.Name = "btnAdicionarQuestao";
            btnAdicionarQuestao.Size = new Size(128, 48);
            btnAdicionarQuestao.TabIndex = 6;
            btnAdicionarQuestao.Text = "Adicionar";
            btnAdicionarQuestao.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRemoverAlternativa);
            groupBox1.Location = new Point(14, 264);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(403, 237);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alternativas";
            // 
            // btnRemoverAlternativa
            // 
            btnRemoverAlternativa.Location = new Point(18, 26);
            btnRemoverAlternativa.Name = "btnRemoverAlternativa";
            btnRemoverAlternativa.Size = new Size(129, 34);
            btnRemoverAlternativa.TabIndex = 0;
            btnRemoverAlternativa.Text = "Remover";
            btnRemoverAlternativa.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(182, 539);
            button1.Name = "button1";
            button1.Size = new Size(111, 49);
            button1.TabIndex = 8;
            button1.Text = "Gravar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 0, 0);
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(306, 539);
            button2.Name = "button2";
            button2.Size = new Size(111, 49);
            button2.TabIndex = 9;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            // 
            // TelaQuestaoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 600);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(btnAdicionarQuestao);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(txtEnunciado);
            Controls.Add(label2);
            Controls.Add(cmbMateria);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaQuestaoForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Questões";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbMateria;
        private Label label2;
        private TextBox txtEnunciado;
        private TextBox textBox1;
        private Label label3;
        private Button btnAdicionarQuestao;
        private GroupBox groupBox1;
        private Button btnRemoverAlternativa;
        private Button button1;
        private Button button2;
    }
}