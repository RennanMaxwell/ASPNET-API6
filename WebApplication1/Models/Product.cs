namespace WebApplication1.Models
{
    // model product for data api sql server capture and show in swagger
    // Field sql server database publi.dbo.ims_investimento_produto
    public class Product
    {

        public int ID { get; set; }

        public string PRODUTO_PUBLI { get; set; }

        public string PRODUTO_FINAL { get; set; }
        public int DIVISOR { get; set; }

        public string DT_INICIAL { get; set; }

        public string DT_FINAL { get; set; }

        public int GRUPO { get; set; }

        public float? PERCENTUAL_RATEIO { get; set; }

        public string CCUSTO_CLI { get; set; }

        public string ORDEM_INTERNA { get; set; }
    }
}
