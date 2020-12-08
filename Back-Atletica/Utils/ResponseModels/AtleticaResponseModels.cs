using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class AtleticaResponseModels
    {
        public class AtleticaPorId
        {
            public int AtleticaId { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Descricao { get; set; }
            public string PIN { get; set; }
            public string Telefone { get; set; }
            public string LinkProsel { get; set; }
            public List<ImagemAtleticasResponseModel> AtleticaImagens { get; set; }
            public CampusResponseModel Campus { get; set; }
            public List<PessoaResponseModel> Membros { get; set; }
            public List<CursosResponseModel> Cursos { get; set; }

            public AtleticaPorId Transform(Atletica atletica)
            {
                AtleticaPorId a = new AtleticaPorId
                {
                    AtleticaId = atletica.AtleticaId,
                    Nome = atletica.Nome,
                    Email = atletica.Email,
                    Descricao = atletica.Descricao,
                    PIN = atletica.PIN,
                    Telefone = atletica.Telefone,
                    LinkProsel = atletica.LinkProsel,
                    Username = atletica.Username
                };

                if (atletica.Campus != null)
                {
                    CampusResponseModel campus = new CampusResponseModel();
                    a.Campus = campus.Transform(atletica.Campus);
                }
                if (atletica.Pessoas.Count > 0)
                {
                    List<PessoaResponseModel> list = new List<PessoaResponseModel>();
                    foreach (Pessoa p in atletica.Pessoas)
                    {
                        if (p.Tipo.Contains("M"))
                        {
                            PessoaResponseModel m = new PessoaResponseModel().Transform(p);
                            if (m != null) list.Add(m);
                        }
                    }
                    a.Membros = list;
                }
                if (atletica.ImagemAtleticas.Count > 0)
                {
                    List<ImagemAtleticasResponseModel> listImg = new List<ImagemAtleticasResponseModel>();

                    foreach (ImagemAtletica i in atletica.ImagemAtleticas)
                    {
                        ImagemAtleticasResponseModel img = new ImagemAtleticasResponseModel().Transform(i);
                        if (img != null) listImg.Add(img);
                    }
                    a.AtleticaImagens = listImg;
                }
                if (atletica.AtleticaCursos.Count > 0)
                {
                    List<CursosResponseModel> cursoList = new List<CursosResponseModel>();

                    foreach (AtleticaCurso c in atletica.AtleticaCursos)
                    {
                        CursosResponseModel curso = new CursosResponseModel().Transform(c.Curso);
                        if (curso != null) cursoList.Add(curso);
                    }
                    a.Cursos = cursoList;
                }
                return a;
            }
        }

    }

    public class CursosResponseModel
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }

        public CursosResponseModel Transform(Curso curso)
        {
            CursosResponseModel cur = new CursosResponseModel
            {
                CursoId = curso.CursoId,
                Nome = curso.Nome
            };

            return cur;
        }
    }

    public class ImagemAtleticasResponseModel
    {
        public char Tipo { get; set; }
        public int ImagemId { get; set; }
        public ImagemResponseModel Imagem { get; set; }

        public ImagemAtleticasResponseModel Transform(ImagemAtletica imgAtletica)
        {
            ImagemResponseModel imagem = new ImagemResponseModel().Transform(imgAtletica.Imagem);
            ImagemAtleticasResponseModel img = new ImagemAtleticasResponseModel
            {
                Tipo = imgAtletica.Tipo,
                ImagemId = imgAtletica.ImagemId,
                Imagem = imagem
            };

            return img;
        }

    }


    public class PessoaResponseModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string Tipo { get; set; }
        public char Genero { get; set; }

        public MembroModel Membro { get; set; }


        public PessoaResponseModel Transform(Pessoa pessoa)
        {
            PessoaResponseModel p = new PessoaResponseModel
            {
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Email = pessoa.Email,
                Whatsapp = pessoa.Whatsapp,
                Tipo = pessoa.Tipo,
                Genero = pessoa.Genero
            };

            if (pessoa.Membro != null)
            {
                MembroModel m = new MembroModel();
                p.Membro = m.Transform(pessoa.Membro);
            }

            return p;

        }
    }

    public class MembroModel
    {
        public int MembroId { get; set; }
        public ImagemResponseModel Imagem { get; set; }

        public MembroModel Transform(Membro membro)
        {
            ImagemResponseModel img = new ImagemResponseModel();

            return new MembroModel
            {
                MembroId = membro.MembroId,
                Imagem = membro.Imagem != null ? img.Transform(membro.Imagem) : null
            };
        }
    }

    public class ImagemResponseModel
    {
        public int ImagemId { get; set; }
        public string Path { get; set; }
        public string Extensao { get; set; }

        public ImagemResponseModel Transform(Imagem img)
        {
            return new ImagemResponseModel
            {
                ImagemId = img.ImagemId,
                Extensao = img.Extensao,
                Path = img.Path
            };

        }
    }

    public class CampusResponseModel
    {
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Nome { get; set; }
        public string Complemento { get; set; }
        public FaculdadeResponseModel Faculdade { get; set; }
        public CampusResponseModel Transform(Campus campus)
        {
            CampusResponseModel c = new CampusResponseModel
            {
                Nome = campus.Nome,
                Cidade = campus.Cidade,
                Bairro = campus.Bairro,
                Rua = campus.Rua,
                Estado = campus.Estado,
                CEP = campus.CEP,
                Complemento = campus.Complemento,

            };
            if (campus.Faculdade != null)
            {
                FaculdadeResponseModel f = new FaculdadeResponseModel();
                c.Faculdade = f.Transform(campus.Faculdade);
            }

            return c;

        }
    }

    public class FaculdadeResponseModel
    {
        public string Nome { get; set; }

        public FaculdadeResponseModel Transform(Faculdade faculdade)
        {
            return new FaculdadeResponseModel { Nome = faculdade.Nome };

        }
    }

}
