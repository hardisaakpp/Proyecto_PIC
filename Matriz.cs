using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_PIC
{
    public class Matriz
    {
        #region Atributos

        private int[,] datos; // Matriz de datos
        private int [,] matrizA; // Matriz de la primera entrada
        private int[,] matrizB; // Matriz de la segunda entrada
        private int[,] resultMatriz; // Matriz resultado de las operaciones
        private int filas; // Número de filas de las matrices
        private int columnas; // Número de columnas de las matrices
        
        #endregion

        #region Constructores

        public Matriz()
        {
            filas = 0;
            columnas = 0;
            datos = new int[filas, columnas];
        }

        // Constructor que acepta filas y columnas
        public Matriz (int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            datos = new int[filas, columnas];
        }

        // Constructor que acepta una matriz de datos
        public Matriz(int[,] datos)
        {
            this.filas = datos.GetLength(0);
            this.columnas = datos.GetLength(1);
            this.datos = datos;
        }

        #endregion

        #region Propiedades

        public int Filas
        {
            get { return filas; }
            set
            {
                if (value > 0)
                {
                    filas = value;
                    // Se puede ajustar la matriz de datos si es necesario
                    datos = new int[filas, columnas];
                }
                else
                {
                    Console.WriteLine("El número de filas debe ser mayor que 0.");
                }
            }
        }

        public int Columnas
        {
            get { return columnas; }
            set
            {
                if (value > 0)
                {
                    columnas = value;
                    // Se puede ajustar la matriz de datos si es necesario
                    datos = new int[filas, columnas];
                }
                else
                {
                    Console.WriteLine("El número de columnas debe ser mayor que 0.");
                }
            }
        }

        // Propiedad para acceder y modificar la matriz de datos
        public int[,] Datos
        {
            get { return datos; }
            set { datos = value; }
        }

        #endregion

        #region Métodos Privados
        // Método privado para validar índices
        private bool IndicesValidos(int fila, int columna)
        {
            return fila >= 0 && fila < filas && columna >= 0 && columna < columnas;
        }

        // Método privado para realizar la suma de dos matrices
        private int[,] SumarMatrices(int[,] matrizA, int[,] matrizB)
        {
            int[,] resultado = new int[filas, columnas];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    resultado[i, j] = matrizA[i, j] + matrizB[i, j];
                }
            }

            return resultado;
        }

        // Método privado para mostrar la matriz
        private void MostrarMatriz()
        {
            Console.WriteLine("Matriz:");
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write(datos[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Métodos Públicos

        // Método público para realizar la suma de dos matrices
        public void SumarMatrices(Matriz matrizB)
        {
            if (filas == matrizB.Filas && columnas == matrizB.Columnas)
            {
                datos = SumarMatrices(datos, matrizB.Datos);
            }
            else
            {
                Console.WriteLine("No se pueden sumar matrices de dimensiones diferentes.");
            }
        }

        // Método público para multiplicar la matriz por un escalar
        public void MultiplicarPorEscalar(int escalar)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    datos[i, j] *= escalar;
                }
            }
        }

        // Método público para mostrar la matriz
        public void MostrarMatriz()
        {
            Console.WriteLine("Matriz:");
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write(datos[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        #endregion
    }
}
