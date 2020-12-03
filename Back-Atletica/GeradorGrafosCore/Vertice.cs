using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorGrafosCore
{
    public class Vertice
    {
        public int id { get; set; }
        public string etiqueta { get; set; }
        public char Cor { get; set; }
        public int Descoberta { get; set; }
        public int Fechamento { get; set; }
        public Vertice Predecssor { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public List<double> PageRank { get; set; }
        public int PosicaoRank { get; set; }
        public int GrauSaida { get; set; }
        public int GrauEntrada { get; set; }


        public List<Vertice> ListaAdjacencia { get; set; }
        public List<Vertice> ListaIncidencia { get; set; }

        public Vertice()
        {
            this.Predecssor = null;
            this.ListaAdjacencia = new List<Vertice>();
            this.ListaIncidencia = new List<Vertice>();
            this.PageRank = new List<double>();
            this.id = 1;
            this.GrauEntrada = 0;
            this.GrauSaida = 0;
            AtualizaCoordenadas();
        }
        
        public void AtualizaCoordenadas()
        {
            Random r = new Random();
            this.PosX = r.Next(800);
            this.PosY = r.Next(600);
        }
    }


}
