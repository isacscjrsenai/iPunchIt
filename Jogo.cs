using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.Menus;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace iPunchIt
{
    internal class Jogo
    {
        private bool isCloseRequested;
        public void Run()
        {
            List<IMenuItem> menuItems = new List<IMenuItem>
            {
                new LabelMenuItem
                {
                    Text = "Iniciar Jogo",
                    Command = new IniciaJogo()
                },
                new LabelMenuItem
                {
                    Text = "Salva Jogo",
                    Command = new SalvaJogo()
                },
                new LabelMenuItem
                {
                    Text = "RECORDS",
                    Command = new MostraRecord()
                },
                new SeparatorMenuItem(),
                new LabelMenuItem
                {
                    Text = "Sair do Jogo",
                    Command = new SairDoJogo(this)
                }
            };
            ScrollMenu menu = new ScrollMenu(menuItems);
            
            while(!isCloseRequested)
            {
                menu.Display();
            }

        }
        public void RequestExit() 
        { 
            isCloseRequested = true;
        }

        internal class SairDoJogo: ICommand
        {
            private readonly Jogo jogo;
            public bool IsActive { get; } = true;
            public SairDoJogo(Jogo jogo)
            {
                if (jogo == null) throw new ArgumentNullException(nameof(jogo));
                this.jogo = jogo;
            }
            public void Execute()
            {
                jogo.RequestExit();
            }
        }

        internal class IniciaJogo: ICommand
        {
            public bool IsActive { get; } = true;

            public void Execute()
            {
                IniciaLuta();
            }
        }
        internal class MostraRecord:ICommand
        {
            public bool IsActive { get; } = true;
            public void Execute()
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = "RECORDS A IMPLEMENTAR",
                    Margin = 1,
                    ForegroundColor = ConsoleColor.Blue
                };
                textBlock.Display();
            }
        }
        internal class SalvaJogo: ICommand
        {
            public bool IsActive { get; } = true;
            public void Execute()
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = "SALVAR A IMPLEMENTAR",
                    Margin = 1,
                    ForegroundColor = ConsoleColor.Red
                };
                textBlock.Display();
            }
        }
        public static void IniciaLuta()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool acabouLuta = false;
            Lutador lutador1 = new();
            Lutador lutador2 = new(isPlayerTop: false);
            Console.Clear();
            Console.Write(lutador1);
            Console.Write(lutador2);
            while (!acabouLuta)
            {
                bool isKeyPressed = false;
                //enquanto não tem tecla no buffer e não se passaram 200 milisegundos
                while (!isKeyPressed && stopwatch.ElapsedMilliseconds < 100)
                {
                    //Se há um movimento do lutadores para atualizar                  
                    if (lutador1.Movimentando || lutador2.Movimentando)
                    {
                        //Limpa a tela
                        Console.Clear();
                        //Console.SetCursorPosition(left:0, top:lutador1.CoordenadaY); //Posiciona o cursor
                        //Desenha o lutador1
                        Console.Write(lutador1);
                        Console.SetCursorPosition(left: 0, top: lutador2.CoordenadaY);//Posiciona o cursor
                        //Desenha o lutador2
                        Console.Write(lutador2);
                        
                        

                    }
                     
                    //Se tem alguma tecla no buffer
                    if(Console.KeyAvailable)
                    {
                        isKeyPressed = true;
                        var key = Console.ReadKey(true); 
                        var comando = key.KeyChar; // Passa a tecla do buffer para o comando
                        //Executa o comando de acordo com qual comando for dado
                        //O usuario vai usar w,a,s,d para movimentar o lutador
                        //E a tecladas q e e para socar, a direita e esquerda respectivamente
                        switch (comando)
                        {
                            case 'a':
                                {
                                    //Move o lutador para esquerda 
                                    lutador1.MoveParaEsquerda();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'd':
                                {
                                    //Move o lutador 1 para direita
                                    lutador1.MoveParaDireita();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'w':
                                {
                                    //Move o lutador 1 para baixo
                                    lutador1.MoveParaCima();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 's':
                                {
                                    //Move o lutador para cima.
                                    lutador1.MoveParaBaixo();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'q':
                                {
                                    lutador1.SocoEsquerda();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'e':
                                {
                                    lutador1.SocoDireita();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'k':
                                {
                                    lutador2.MoveParaEsquerda();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'ç':
                                {
                                    lutador2.MoveParaDireita();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'o':
                                {
                                    lutador2.MoveParaCima();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'l':
                                {
                                    lutador2.MoveParaBaixo();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'i':
                                {
                                    lutador2.SocoEsquerda();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                            case 'p':
                                {
                                    lutador2.SocoDireita();
                                    //Reinicia o contador de tempo
                                    stopwatch.Restart();
                                }
                                break;
                        }
                    }
                    if (lutador1.Vida <= 0 || lutador2.Vida <= 0)
                    {
                        acabouLuta = true;
                    }
                }
                //Se nenhuma tecla for apertada e o contador não foi reiniciado 
                //Coloca o lutador na posição parado
                //Desenha o lutador 1
                Console.Clear();
                Console.SetCursorPosition(left:0,top: lutador1.CoordenadaY); //Posiciona o cursor
                Console.Write(lutador1);
                Console.SetCursorPosition(left: 0, top: lutador2.CoordenadaY); //Posiciona o cursor
                Console.Write(lutador2);
                lutador1.Parado();
                lutador2.Parado();
                //se passar 200 milisegundos sem apertarem alguma tecla
                //Reinicia o contador de tempo
                stopwatch.Restart();

            }
        }
    }
}
