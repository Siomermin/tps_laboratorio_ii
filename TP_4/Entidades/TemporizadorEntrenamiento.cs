using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class TemporizadorEntrenamiento
    {
        public delegate void DelegadoTemporizador();

        public event DelegadoTemporizador TiempoCumplido;

        private Task hilo;
        private int intervalo;
        private CancellationTokenSource cancellationTokenSource;

        public int Intervalo { get => intervalo; set => intervalo = value; }

        public bool EstaActivo { get => hilo is not null && hilo.Status == TaskStatus.Running; }

        public TemporizadorEntrenamiento(int intervalo)
        {
            this.intervalo = intervalo;
        }

        public void IniciarTemporizadorEntrenamiento()
        {
            if (hilo is null || hilo.IsCompleted)
            {
                cancellationTokenSource = new CancellationTokenSource();
            
                hilo = new Task(CorrerTiempo, cancellationTokenSource.Token);
            }

            if (!EstaActivo)
            {
                hilo.Start();
            }
        }

        public void DetenerTemporizadorEntrenamiento()
        {
            if (hilo is not null && !hilo.IsCompleted)
            {
                cancellationTokenSource.Cancel();
            }
        }
        private void CorrerTiempo()
        {
            do
            {
                if (TiempoCumplido is not null)
                {
                    TiempoCumplido.Invoke();
                }

                Thread.Sleep(intervalo);

            } while (!cancellationTokenSource.IsCancellationRequested);       
        }
    }
}
