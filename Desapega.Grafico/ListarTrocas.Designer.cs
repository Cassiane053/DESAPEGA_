namespace Desapega.Grafico
{
    partial class ListarTrocas
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
            this.dgTrocas = new System.Windows.Forms.DataGridView();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.btAtualizar = new System.Windows.Forms.Button();
            this.tbAdicionarProduto = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrocas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTrocas
            // 
            this.dgTrocas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTrocas.Location = new System.Drawing.Point(12, 12);
            this.dgTrocas.Name = "dgTrocas";
            this.dgTrocas.Size = new System.Drawing.Size(545, 202);
            this.dgTrocas.TabIndex = 0;
            this.dgTrocas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTrocas_CellContentClick);
            // 
            // btAdicionar
            // 
            this.btAdicionar.Location = new System.Drawing.Point(388, 233);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btAdicionar.TabIndex = 1;
            this.btAdicionar.Text = "Adicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // btAtualizar
            // 
            this.btAtualizar.Location = new System.Drawing.Point(469, 233);
            this.btAtualizar.Name = "btAtualizar";
            this.btAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btAtualizar.TabIndex = 2;
            this.btAtualizar.Text = "Atualizar";
            this.btAtualizar.UseVisualStyleBackColor = true;
            this.btAtualizar.Click += new System.EventHandler(this.btAtualizar_Click);
            // 
            // tbAdicionarProduto
            // 
            this.tbAdicionarProduto.Location = new System.Drawing.Point(17, 233);
            this.tbAdicionarProduto.Name = "tbAdicionarProduto";
            this.tbAdicionarProduto.Size = new System.Drawing.Size(75, 23);
            this.tbAdicionarProduto.TabIndex = 4;
            this.tbAdicionarProduto.Text = "+ Produto";
            this.tbAdicionarProduto.UseVisualStyleBackColor = true;
            this.tbAdicionarProduto.Click += new System.EventHandler(this.tbAdicionarProduto_Click);
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.Location = new System.Drawing.Point(98, 233);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverProduto.TabIndex = 6;
            this.btnRemoverProduto.Text = "- Produto";
            this.btnRemoverProduto.UseVisualStyleBackColor = true;
            this.btnRemoverProduto.Click += new System.EventHandler(this.btnRemoverProduto_Click);
            // 
            // ListarTrocas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 272);
            this.Controls.Add(this.btnRemoverProduto);
            this.Controls.Add(this.tbAdicionarProduto);
            this.Controls.Add(this.btAtualizar);
            this.Controls.Add(this.btAdicionar);
            this.Controls.Add(this.dgTrocas);
            this.Name = "ListarTrocas";
            this.Text = "Listar Troca";
            this.Load += new System.EventHandler(this.ListarTrocas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTrocas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTrocas;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.Button btAtualizar;
        private System.Windows.Forms.Button tbAdicionarProduto;
        private System.Windows.Forms.Button btnRemoverProduto;
    }
}