namespace ProAgil.Domain
{
    public class Lote
    {
      public int Id { get; set; }
      public string Nome { get; set; }
      public decimal Preco { get; set; }
      public System.DateTime? DataInicio { get; set; }  
      public System.DateTime? DataFim { get; set; }  
      public int Quatidade { get; set; }
      public int EventoId { get; set; }
      public Evento Evento { get; set; }
    }
}
