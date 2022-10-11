using System;

namespace ObjetoTransferencia
{
    public class Pessoal
    {
      /* Modelo padrão de encapsulamento  
          private int id;
          public int getId()
          {
            return id;
          }
          public void setId(int idEnviado)
          {
            id = idEnviado;
          }   */

        // Modelo de encapsulamento do .NET
        public int id { get; set; }
        public DateTime datacad{ get; set; }
        public string nome { get; set; }
        public DateTime nascimento { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public object foto { get; set; }
        public object digital { get; set; }
        public string evangelico { get; set; }
        public string ibrn { get; set; }
        public string igreja { get; set; }
        public int ano { get; set; }
        public int num { get; set; }
        public int frequencia { get; set; }
        public string Lider { get; set; }
        public string grupo { get; set; }

    }
}
