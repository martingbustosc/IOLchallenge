/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        /*
         Aquí surge un dilema, como ya existían tres formas que funcionan con el constructor y métodos existentes.
         Hay dos posibilidades: 
         1- Crear una clase "FormaGenerica", y luego implementar polimorfismo. Una clase por cada "figura en particular" que hereden las propiedades de la clase padre "FormaGenerica".
            Métodos a heredar y sobreescribir por ej: CalcularArea y CalcularPerimetro, ya que esos calculos varian para cada figura.
         2- La solución implementada. Se agregaron dos campos (_base y _altura), medidas necesarias para los calculos en la figura nueva "Trapecio Rectangulo". Para 
            las tres figuras existentes (_lado sigue existiendo, y los campos nuevos por default van en 0 ya que no necesitan esas medidas). Se modificó el constructor para
            que acepte los casos posibles para este ejercicio.

         Respecto al idioma: decidí agregar tres idiomas extras, Portugues, Frances e Italiano. Implementar switch en lugar de multiples if ya que las posibilidades son mayores,
         y es más óptimo que ir comparando por cada uno. Para cada case del switch de idioma, su traducción, dejando por default a Inglés.
         */

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        //public const int Ingles = 2; //DEFAULT
        public const int Portugues = 3;
        public const int Frances = 4;
        public const int Italiano = 5;

        #endregion

        private readonly decimal _lado;//lado o radio para las tres primeras figuras, una de las bases para trapecio
        private readonly decimal _base;
        private readonly decimal _altura;

        public int Tipo { get; set; }

        //public FormaGeometrica(int tipo, decimal ancho)
        //{
        //    Tipo = tipo;
        //    _lado = ancho;
        //}

        public FormaGeometrica(int tipo, decimal ancho, decimal alto = 0, decimal _base = 0)//constructor que abarque a Trapecio como figura y sus medidas para el calculo de su area y perimetro
        {
            Tipo = tipo;
            _lado = ancho;
            _altura = alto;
            this._base = _base;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                //if (idioma == Castellano)
                //    sb.Append("<h1>Lista vacía de formas!</h1>");
                //else
                //    sb.Append("<h1>Empty list of shapes!</h1>");

                //SOLUCION IDIOMA
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("<h1>Lista vacía de formas!</h1>");
                        break;

                    case Portugues:
                        sb.Append("<h1>Lista vazia de formas!</h1>");
                        break;

                    case Frances:
                        sb.Append("<h1>Liste vide de formes !</h1>");
                        break;

                    case Italiano:
                        sb.Append("<h1>Lista vuota di forme!</h1>");
                        break;

                    default:
                        sb.Append("<h1>Empty list of shapes!</h1>");//INGLES DEFAULT
                        break;
                }
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                //if (idioma == Castellano)
                //    sb.Append("<h1>Reporte de Formas</h1>");
                //else
                //    // default es inglés
                //    sb.Append("<h1>Shapes report</h1>");

                // HEADER
                //SOLUCION IDIOMA
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("<h1>Reporte de Formas</h1>");
                        break;

                    case Portugues:
                        sb.Append("<h1>Relatório de formas</h1>");
                        break;

                    case Frances:
                        sb.Append("<h1>Rapport sur les formes</h1>");
                        break;

                    case Italiano:
                        sb.Append("<h1>Rapporto sulle forme</h1>");
                        break;

                    default:
                        sb.Append("<h1>Shapes report</h1>");//INGLES DEFAULT
                        break;
                }

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;
                var numeroTrapecios = 0;//SOLUCION

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaTraprecios = 0m;//SOLUCION

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroTraprecios = 0m;//SOLUCION

                //for (var i = 0; i < formas.Count; i++)
                //{
                //    if (formas[i].Tipo == Cuadrado)
                //    {
                //        numeroCuadrados++;
                //        areaCuadrados += formas[i].CalcularArea();
                //        perimetroCuadrados += formas[i].CalcularPerimetro();
                //    }
                //    if (formas[i].Tipo == Circulo)
                //    {
                //        numeroCirculos++;
                //        areaCirculos += formas[i].CalcularArea();
                //        perimetroCirculos += formas[i].CalcularPerimetro();
                //    }
                //    if (formas[i].Tipo == TrianguloEquilatero)
                //    {
                //        numeroTriangulos++;
                //        areaTriangulos += formas[i].CalcularArea();
                //        perimetroTriangulos += formas[i].CalcularPerimetro();
                //    }
                //}

                //SOLUCÓN: de esta manera se realizan menos comparaciones (multiples if, más las de cada iteracion del for) y operaciones (declaración e incremento de la variable i).
                //La complejidad algorítmica disminuye, resultando en una ejecución mas óptima.
                foreach (var forma in formas)
                {
                    switch (forma.Tipo)
                    {
                        case Cuadrado:
                            numeroCuadrados++;
                            areaCuadrados += forma.CalcularArea();
                            perimetroCuadrados += forma.CalcularPerimetro();
                            break;

                        case TrianguloEquilatero:
                            numeroTriangulos++;
                            areaTriangulos += forma.CalcularArea();
                            perimetroTriangulos += forma.CalcularPerimetro();
                            break;

                        case Circulo:
                            numeroCirculos++;
                            areaCirculos += forma.CalcularArea();
                            perimetroCirculos += forma.CalcularPerimetro();
                            break;

                        case Trapecio:
                            numeroTrapecios++;
                            areaTraprecios += forma.CalcularArea();
                            perimetroTraprecios += forma.CalcularPerimetro();
                            break;
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));
                sb.Append(ObtenerLinea(numeroTrapecios, areaTraprecios, perimetroTraprecios, Trapecio, idioma));

                // FOOTER
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("TOTAL:<br/>");
                        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + "formas" + " ");
                        sb.Append("Perimetro " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
                        break;

                    case Portugues:
                        sb.Append("TOTAL:<br/>");
                        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + "formas" + " ");
                        sb.Append("Perímetro " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
                        break;

                    case Frances:
                        sb.Append("LE TOTAL:<br/>");
                        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + "formes" + " ");
                        sb.Append("Périmètre " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                        sb.Append("Aire " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
                        break;

                    case Italiano:
                        sb.Append("TOTALE:<br/>");
                        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + "forme" + " ");
                        sb.Append("Perimetro " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
                        break;

                    default://INGLES DEFAULT
                        sb.Append("TOTAL:<br/>");
                        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + "shapes" + " ");
                        sb.Append("Perimeter " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
                        break;
                }

            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                //if (idioma == Castellano)
                //    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                //return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";

                switch (idioma)
                {
                    case Castellano: return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Área {area:#.##} | Perímetro {perimetro:#.##} <br/>";//ESPAÑOL
                    case Portugues: return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Área {area:#.##} | Perímetro {perimetro:#.##} <br/>";//PORTUGUES
                    case Frances: return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Région {area:#.##} | Périmètre {perimetro:#.##} <br/>";//FRANCES
                    case Italiano: return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";//ITALIANO
                    default: return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";//INGLES DEFAULT
                }
            }

            return string.Empty;
        }

        //private static string TraducirForma(int tipo, int cantidad, int idioma)
        //{
        //    switch (tipo)
        //    {
        //        case Cuadrado:
        //            if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
        //            else return cantidad == 1 ? "Square" : "Squares";
        //        case Circulo:
        //            if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
        //            else return cantidad == 1 ? "Circle" : "Circles";
        //        case TrianguloEquilatero:
        //            if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
        //            else return cantidad == 1 ? "Triangle" : "Triangles";
        //        case Trapecio:
        //            if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
        //            else return cantidad == 1 ? "Triangle" : "Triangles";
        //    }

        //    return string.Empty;
        //}

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (idioma)
            {
                case Castellano:
                    switch (tipo)
                    {
                        case Cuadrado: return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                        case Circulo: return cantidad == 1 ? "Triangulo" : "Triangulos";
                        case TrianguloEquilatero: return cantidad == 1 ? "Círculo" : "Círculos";
                        case Trapecio: return cantidad == 1 ? "Trapecio" : "Trapecios";
                    }
                    break;

                case Portugues:
                    switch (tipo)
                    {
                        case Cuadrado: return cantidad == 1 ? "Quadrado" : "Quadrados";
                        case Circulo: return cantidad == 1 ? "Triângulo" : "Triângulos";
                        case TrianguloEquilatero: return cantidad == 1 ? "Círculo" : "Círculos";
                        case Trapecio: return cantidad == 1 ? "Trapézio" : "Trapézios";

                    }
                    break;

                case Frances:
                    switch (tipo)
                    {
                        case Cuadrado: return cantidad == 1 ? "Carré" : "Carrés";
                        case Circulo: return cantidad == 1 ? "Triangle" : "Triangles";
                        case TrianguloEquilatero: return cantidad == 1 ? "Cercle" : "Cercles";
                        case Trapecio: return cantidad == 1 ? "Trapèze" : "Trapèzes";

                    }
                    break;

                case Italiano:
                    switch (tipo)
                    {
                        case Cuadrado: return cantidad == 1 ? "Piazza" : "Piazze";
                        case Circulo: return cantidad == 1 ? "Triangolo" : "Triangli";
                        case TrianguloEquilatero: return cantidad == 1 ? "Cerchio" : "Cerchi";
                        case Trapecio: return cantidad == 1 ? "Trapezio" : "Trapezi";
                    }
                    break;

                default://INGLES
                    switch (tipo)
                    {
                        case Cuadrado: return cantidad == 1 ? "Square" : "Squares";
                        case Circulo: return cantidad == 1 ? "Triangle" : "Triangles";
                        case TrianguloEquilatero: return cantidad == 1 ? "Circle" : "Circles";
                        case Trapecio: return cantidad == 1 ? "Trapeze" : "Trapezoids";
                    }
                    break;
            }

            return string.Empty;
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                case Trapecio: return _altura * ((_lado + _base) / 2);// area trapecio rectangulo
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                case Trapecio: return (_lado + _base + _altura + CalcularCateto(_altura, _base - _lado));// perimetro trapecio rectangulo
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        //
        // Resumen:
        //     Devuelve la medida del cateto faltante en un triángulo rectángulo.
        //
        // Parámetros:
        //   a:
        //     Número que representa la medida de uno de los catetos.
        //   b:
        //     Número que representa la medida del otro cateto conocido.
        //
        // Devuelve:
        //     La medida del cateto faltante en el tríangulo rectángulo como decimal.
        //
        // Nota: este método se podría implementar en una hipotética clase hija "TranguloRectangulo" que herede de "FiguraGenerica"
        public decimal CalcularCateto(decimal a, decimal b)
        {
            return (decimal)Math.Sqrt((double)((a * a) + (b * b)));
        }
    }
}
