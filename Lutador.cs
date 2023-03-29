using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPunchIt
{
    internal class Lutador
    {
        public List<string> Posicoes;
        public List<string> Arms;
        private int coordenadaX; 
        private int coordenadaY;
        public int Vida;
        private bool socandoEsquerda;
        private bool socandoDireita;
        public bool atingido;
        private bool movimentando;

        public int CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
        public int CoordenadaY { get => coordenadaY; set => coordenadaY = value; }
        public bool Movimentando => movimentando;
        private readonly bool isPlayerTop;
        public Lutador(bool isPlayerTop = true)
        {
            this.isPlayerTop = isPlayerTop;
            if (isPlayerTop )
            {
                CoordenadaX = 0;
                CoordenadaY = 0;
            }
            else
            {
                CoordenadaX = 99;
                CoordenadaY = 19;
            }
            Vida = 100;
            socandoDireita = false;
            socandoEsquerda = false;
            atingido = false;
            movimentando = false;
            if (isPlayerTop)
            {
                this.Posicoes = new List<string>
        {
            $@"
      __
     /  \
  ┌─┤<><>├─┐
 /   \__/   \
/            \
\            /
 \          /
  ▀        ▀",
            $@"
      __
     /  \
  ┌─┤<><>├─┐
  |  \__/   \
  |          \
  |          /
  |         /
  |        ▀
  |        
  |
  █▀",
            $@"
      __
     /  \
  ┌─┤<><>├─┐
 /   \__/  |
/          |
\          |
 \         |
  ▀        |
           |
           |
          ▀█",
            $@"
      \ |/
|     /  \        
|  ┌─┤X  X├─┐    /
| /   \__/   \  /
|/            \/",
        };
            }
            else
            {
                string e = new(' ', this.CoordenadaX);
                this.Posicoes = new List<string>
                {
                   
                   $@"
{e}  ▄        ▄
{e} /          \
{e}/            \
{e}\     __     /
{e} \   /  \   /
{e}  └─┤<><>├─┘
{e}     \__ /
",
                    $@"
{e} ▄█
{e}  |
{e}  |
{e}  |        ▄ 
{e}  |         \
{e}  |          \
{e}  |   __     /
{e}  |  /  \   /
{e}  └─┤<><>├─┘
{e}     \__/
",
                    $@"
{e}          ▄█
{e}           |
{e}           |
{e}  ▄        |
{e} /	      |
{e}/          |
{e}\     __   |
{e} \   /  \  |
{e}  └─┤<><>├─┘
{e}     \__/
",
                    $@"
{e}|\     __     /\
{e}| \   /  \   /  \   
{e}|  └─┤X  X├─┘    \
{e}|     \  /     
{e}      / |\       
",
                };
            }
            
        }
        public void AtualizaPosicoes()
        {
            string e = new(' ', this.CoordenadaX);
            if (isPlayerTop)
            {
                this.Posicoes = new List<string>
        {
            $@"
{e}      __
{e}     /  \
{e}  ┌─┤<><>├─┐
{e} /   \__/   \
{e}/            \
{e}\            /
{e} \          /
{e}  ▀        ▀",
            $@"
{e}      __
{e}     /  \
{e}  ┌─┤<><>├─┐
{e}  |  \__/   \
{e}  |          \
{e}  |          /
{e}  |         /
{e}  |        ▀
{e}  |        
{e}  |
{e}  █▀",
            $@"
{e}      __
{e}     /  \
{e}  ┌─┤<><>├─┐
{e} /   \__/  |
{e}/          |
{e}\          |
{e} \         |
{e}  ▀        |
{e}           |
{e}           |
{e}          ▀█",
            $@"
{e}      \ |/
{e}|     /  \        
{e}|  ┌─┤X  X├─┐    /
{e}| /   \__/   \  /
{e}|/            \/",
        };
            }
            else
            {
                this.Posicoes = new List<string>
                {
                    $@"
{e}  ▄        ▄
{e} /	       \
{e}/            \
{e}\     __     /
{e} \   /  \   /
{e}  └─┤<><>├─┘
{e}     \__/
",
                    $@"
{e} ▄█
{e}  |
{e}  |
{e}  |        ▄ 
{e}  |         \
{e}  |          \
{e}  |   __     /
{e}  |  /  \   /
{e}  └─┤<><>├─┘
{e}     \__/
",
                    $@"
{e}          ▄█
{e}           |
{e}           |
{e}  ▄        |
{e} /	      |
{e}/          |
{e}\     __   |
{e} \   /  \  |
{e}  └─┤<><>├─┘
{e}     \__/
",
                    $@"
{e}|\     __     /\
{e}| \   /  \   /  \   
{e}|  └─┤X  X├─┘    \
{e}|     \  /     
{e}      / |\       
",
                };
            }
        }
        public void MoveParaEsquerda()
        {
            if(this.CoordenadaX >= 1)
            {
                this.CoordenadaX--;
                this.movimentando = true;
                this.AtualizaPosicoes();
            }
            
        }
        public void MoveParaDireita()
        {
            if(this.CoordenadaX <= 99)
            {
                this.CoordenadaX++;
                this.movimentando = true;
                this.AtualizaPosicoes();
            }
           
        }
        public void MoveParaCima()
        {
            //Se for o lutador 1
            if(isPlayerTop)
            {
                if (this.CoordenadaY >= 1)
                {
                    this.CoordenadaY--;
                    this.movimentando = true;
                    this.AtualizaPosicoes();
                }
            } 
            else
            {
                if (this.CoordenadaY >= 10)
                {
                    this.CoordenadaY--;
                    this.movimentando = true;
                    this.AtualizaPosicoes();
                }
            }
            
            
        }
        public void MoveParaBaixo()
        {
            if (isPlayerTop)
            {
                if (this.CoordenadaY <= 10)
                {
                    this.CoordenadaY++;
                    this.movimentando = true;
                    this.AtualizaPosicoes();
                }
            }
            else
            {
                if (this.CoordenadaY <= 20)
                {
                    this.CoordenadaY++;
                    this.movimentando = true;
                    this.AtualizaPosicoes();
                }
            }
            
             
        }
        public void Parado()
        {
            this.movimentando = false;
            this.socandoDireita = false;
            this.socandoEsquerda = false;
            this.AtualizaPosicoes();
        }

        public void SocoDireita()
        {
            this.socandoDireita = true;
            this.socandoEsquerda = false;
            this.AtualizaPosicoes();
        }
        public void SocoEsquerda()
        {
            this.socandoDireita = false;
            this.socandoEsquerda = true;
            this.AtualizaPosicoes();
        }
        public override string ToString()
        {
            if (movimentando)
            {
                return this.Posicoes[0];
            }
            if(atingido)
            {
                return this.Posicoes[3];
            }
            if(socandoDireita)
            {
                return this.Posicoes[2];
            }
            if (socandoEsquerda)
            {
                return this.Posicoes[1];
            }
            return this.Posicoes[0];
        }


    }
}
