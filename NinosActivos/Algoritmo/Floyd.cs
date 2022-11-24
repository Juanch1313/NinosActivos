using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinosActivos.Modelos;
using NinosActivos.Mysql;

namespace NinosActivos.Algoritmo
{
    internal class Floyd
    {
        private static List<Ejercicio> Ejercicios = Selecciones.ObtenerEjercicios();
        private static List<Ejercicio> PlanPropuesto = new List<Ejercicio>();
        private static Ejercicio[,] Matriz =
        {
            {Ejercicios[0], null, null, Ejercicios[3], null, null, Ejercicios[6], null, null, Ejercicios[9], null, null },
            {null, Ejercicios[1], null, null, Ejercicios[4], null, null, Ejercicios[7], null, null, Ejercicios[10], null},
            {null, null, Ejercicios[2], null, null, Ejercicios[5], null, null, Ejercicios[8], null, null, Ejercicios[11]},
            {null, null, null, Ejercicios[3], null, null, Ejercicios[6], null, null, Ejercicios[9], null, null },
            {null, null, null, null, Ejercicios[4], null, null, Ejercicios[7], null, null, Ejercicios[10], null},
            {null, null, null, null, null, Ejercicios[5], null, null, Ejercicios[8], null, null, Ejercicios[11]},
            {null, null, null, null, null, null, Ejercicios[6], null, null, Ejercicios[9], null, null },
            {null, null, null, null, null, null, null, Ejercicios[7], null, null, Ejercicios[10], null},
            {null, null, null, null, null, null, null, null, Ejercicios[8], null, null, Ejercicios[11]},
            {null, null, null, null, null, null, null, null, null, Ejercicios[9], null, null },
            {null, null, null, null, null, null, null, null, null, null, Ejercicios[10], null},
            {null, null, null, null, null, null, null, null, null, null, null, Ejercicios[11]},
        };

        public Floyd()
        {
        }

        public static List<Ejercicio> ObtenerPlan(char Dificultad)
        {
            RealizarAlgoritmo(Dificultad);
            return PlanPropuesto;
        }

        private static void RealizarAlgoritmo(char Dificultad)
        {
            PlanPropuesto.Clear();
            int verticesCount = 12;
            switch (Dificultad)
            {
                //Plan Facil
                case 'F':
                    {
                        Ejercicio[,] distancia = new Ejercicio[verticesCount, verticesCount];

                        for (int i = 0; i < verticesCount; ++i)
                            for (int j = 0; j < verticesCount; ++j)
                                distancia[i, j] = Matriz[i, j];

                        for (int k = 0; k < verticesCount; ++k)
                        {
                            for (int i = 0; i < verticesCount; ++i)
                            {
                                for (int j = 0; j < verticesCount; ++j)
                                {
                                    if(distancia[i, k] != null && distancia[k, j] != null && distancia[i, j] != null) 
                                    {
                                        if (distancia[i, k].ID + distancia[k, j].ID < distancia[i, j].ID)
                                        {
                                            distancia[i, j].ID = distancia[i, k].ID + distancia[k, j].ID;
                                        }
                                        if (distancia[i, k].Dificultad == 'F' && !PlanPropuesto.Contains(distancia[i, k])) 
                                        { PlanPropuesto.Add(distancia[i, k]); }
                                    }
                                }
                            }
                        }
                    }
                    break;
                //Plan Medio
                case 'M':
                    {
                        Ejercicio[,] distancia = new Ejercicio[verticesCount, verticesCount];

                        for (int i = 0; i < verticesCount; ++i)
                            for (int j = 0; j < verticesCount; ++j)
                                distancia[i, j] = Matriz[i, j];

                        for (int k = 0; k < verticesCount; ++k)
                        {
                            for (int i = 0; i < verticesCount; ++i)
                            {
                                for (int j = 0; j < verticesCount; ++j)
                                {
                                    if (distancia[i, k] != null && distancia[k, j] != null && distancia[i, j] != null)
                                    {
                                        if (distancia[i, k].ID + distancia[k, j].ID < distancia[i, j].ID)
                                        {
                                            distancia[i, j].ID = distancia[i, k].ID + distancia[k, j].ID;
                                        }
                                        if (distancia[i, k].Dificultad == 'M' && !PlanPropuesto.Contains(distancia[i, k])) 
                                        { PlanPropuesto.Add(distancia[i, k]); }
                                    }
                                }
                            }
                        }
                    }
                    break;
                //Plan Dificil
                case 'D':
                    {
                        Ejercicio[,] distancia = new Ejercicio[verticesCount, verticesCount];

                        for (int i = 0; i < verticesCount; ++i)
                            for (int j = 0; j < verticesCount; ++j)
                                distancia[i, j] = Matriz[i, j];

                        for (int k = 0; k < verticesCount; ++k)
                        {
                            for (int i = 0; i < verticesCount; ++i)
                            {
                                for (int j = 0; j < verticesCount; ++j)
                                {
                                    if (distancia[i, k] != null && distancia[k, j] != null && distancia[i, j] != null)
                                    {
                                        if (distancia[i, k].ID + distancia[k, j].ID < distancia[i, j].ID)
                                        {
                                            distancia[i, j].ID = distancia[i, k].ID + distancia[k, j].ID;
                                        }
                                        if (distancia[i, k].Dificultad == 'D' && !PlanPropuesto.Contains(distancia[i, k])) 
                                        { PlanPropuesto.Add(distancia[i, k]); }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
}
