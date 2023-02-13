using System;

namespace Autoglass.Architecture.Application.Models
{
    public class CreateProdutoModel
    {
        public int CodProduto { get; set; }
        public string DescProduto { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; } = DateTime.Now;
        public DateTime DataValidade { get; set; } = DateTime.Now;
        public int CodFornecedor { get; set; }
        public string DescFornecedor { get; set; }
        public int CnpjFornecedor { get; set; }
    }
}
