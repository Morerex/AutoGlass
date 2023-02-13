using System;

namespace Autoglass.Architecture.Application.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public int CodProduto { get; set; }
        public string DescProduto { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodFornecedor { get; set; }
        public string DescFornecedor { get; set; }
        public int CnpjFornecedor { get; set; }
    }
}
