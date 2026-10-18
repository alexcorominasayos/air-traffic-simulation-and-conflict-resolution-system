using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        string id; // identificador
        Position initialPosition; // posicion inicial
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;
        int combustible;

        // Constructures
        public FlightPlan(string id, double ipx, double ipy, double cpx, double cpy, double fpx, double fpy, double velocidad, int combustible)
        {
            this.id = id;
            this.initialPosition = new Position(ipx, ipy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.combustible = combustible;
        }
        public FlightPlan()
        {

        }

        // Metodos
        public void setComb(int  combustible)
        { this.combustible = combustible; }
        public int getComb()
        { return this.combustible; }

        public void SetInitialPosition(double ipx, double ipy)
        { this.initialPosition = new Position(ipx, ipy); }
        public Position GetInitialPosition()
        { return this.initialPosition; }

        public void SetId(string id)
        { this.id = id; }
        public string getId()
        { return this.id; }

        public void SetCurrentPosition(double cpx, double cpy)
        { this.currentPosition = new Position(cpx, cpy); }
        public Position GetCurrentPosition()
        { return this.currentPosition; }

        public void SetFinalPosition(double fpx, double fpy)
        { this.finalPosition = new Position(fpx, fpy); }
        public Position GetfinalPosition()
        { return this.finalPosition; }

        public void SetVelocidad(double velocidad)
        { this.velocidad = velocidad; }
        public double GetVelocidad()
        { return this.velocidad; }

        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            Position nextPosition = new Position(x, y);

            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
        }

        public bool HasArrived()
        {
            bool resultado = false;
            if (currentPosition == finalPosition)
                resultado = true;
            return resultado;
        }


        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;

            if (this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
                conflicto = true;

            return conflicto;
        }

        public double DistanciaEntreVuelos(FlightPlan a, FlightPlan b)
        {
            double distancia = Math.Sqrt(Math.Abs(((Math.Abs(a.currentPosition.GetX() - b.GetCurrentPosition().GetX()) * Math.Abs(a.currentPosition.GetX() - b.GetCurrentPosition().GetX())) + (Math.Abs(a.currentPosition.GetY() - b.GetCurrentPosition().GetY()) * Math.Abs(a.currentPosition.GetY() - b.GetCurrentPosition().GetX())))));
            return distancia;
        }

        public Position Restart()
        {
            double x = this.initialPosition.GetX();
            double y = this.initialPosition.GetY();
            this.SetCurrentPosition(x, y);
            return currentPosition;
        }

        public bool HayConflicto(int DistanciaSeguridad, FlightPlan plan)
        {
            // PONER DISTANCIA PERPENDICULAR EN EL ELSE Y COMPARAR LAS DISTANCIAS DEL VECTOR DE DISTANCIA Y SACAR LA MENOR

            double distanciaNORM, t, HA, HB, cosA, cosB, sinA, sinB, OX, OY, CV, SV, distancia;
            double trecorrerA, trecorrerB, trecorrerRAP, trecorrerLEN, distanciaI, distanciaF;
            double distanciaPERP, XA, YA, XB1, YB1, XB, YB, XA1, YA1, vBcosB, vBsinB, XA_XB1, YA_YB1, vAcosA, vAsinA, XB_XA1, YB_YA1, tPERP;

            Position AI = new Position(this.GetInitialPosition().GetX(), this.GetInitialPosition().GetY());
            Position BI = new Position(plan.GetInitialPosition().GetX(), plan.GetInitialPosition().GetY());
            Position AF = new Position(this.GetfinalPosition().GetX(), this.GetfinalPosition().GetY());
            Position BF = new Position(plan.GetfinalPosition().GetX(), plan.GetfinalPosition().GetY());

            HA = Math.Sqrt((AF.GetX() - AI.GetX()) * (AF.GetX() - AI.GetX()) + (AF.GetY() - AI.GetY()) * (AF.GetY() - AI.GetY()));
            HB = Math.Sqrt((BF.GetX() - BI.GetX()) * (BF.GetX() - BI.GetX()) + (BF.GetY() - BI.GetY()) * (BF.GetY() - BI.GetY()));

            cosA = (AF.GetX() - AI.GetX()) / (HA);
            sinA = (AF.GetY() - AI.GetY()) / (HA);
            cosB = (BF.GetX() - BI.GetX()) / (HB);
            sinB = (BF.GetY() - BI.GetY()) / (HB);

            OX = AI.GetX() - BI.GetX();
            OY = AI.GetY() - BI.GetY();
            CV = ((this.GetVelocidad() * cosA) - (plan.GetVelocidad() * cosB));
            SV = ((this.GetVelocidad() * sinA) - (plan.GetVelocidad() * sinB));

            if ((CV == 0) && (SV == 0))
            {
                // Caso particular
                // Los dos vuelos van en la misma dirección (y sentido) con la misma velocidad: distancia constante.
                distancia = Math.Sqrt((AI.GetX() - BI.GetX()) * (AI.GetX() - BI.GetX()) + (AI.GetY() - BI.GetY()) * (AI.GetY() - BI.GetY()));
            }
            else
            {
                trecorrerA = (HA / this.GetVelocidad());
                trecorrerB = (HB / plan.GetVelocidad());
                if (trecorrerA < trecorrerB)
                {
                    trecorrerRAP = trecorrerA;
                    trecorrerLEN = trecorrerB;
                }
                else
                {
                    trecorrerRAP = trecorrerB;
                    trecorrerLEN = trecorrerA;
                }

                t = -(OX * CV + OY * SV) / (CV * CV + SV * SV);

                if (t < 0 || t > trecorrerRAP)
                {
                    t = 0;
                    distanciaI = Math.Sqrt((OX + CV * t) * (OX + CV * t) + (OY + SV * t) * (OY + SV * t)); // Distancia con los dos puntos parados en el inicio
                    distanciaF = Math.Sqrt((BF.GetX() - AF.GetX()) * (BF.GetX() - AF.GetX()) + (BF.GetY() - AF.GetY()) * (BF.GetY() - AF.GetY()));

                    if (trecorrerRAP == trecorrerA)
                    {
                        XA = AF.GetX();
                        YA = AF.GetY();
                        XB1 = BI.GetX();
                        YB1 = BI.GetY();

                        // ENCONTRAR LA DISTANCIA PERPENDICULAR
                        vBcosB = plan.GetVelocidad() * cosB;
                        vBsinB = plan.GetVelocidad() * sinB;
                        XA_XB1 = XA - XB1;
                        YA_YB1 = YA - YB1;

                        tPERP = (XA_XB1 * vBcosB + YA_YB1 * vBsinB) / (vBcosB * vBcosB + vBsinB * vBsinB);
                        if (tPERP >= trecorrerRAP && tPERP <= trecorrerLEN)
                        { distanciaPERP = Math.Sqrt((XA_XB1 - vBcosB * tPERP) * (XA_XB1 - vBcosB * tPERP) + (YA_YB1 - vBsinB * tPERP) * (YA_YB1 - vBsinB * tPERP)); }
                        else
                        { distanciaPERP = -1; }
                    }
                    else
                    {
                        XB = BF.GetX();
                        YB = BF.GetY();
                        XA1 = AI.GetX();
                        YA1 = AI.GetY();

                        // ENCONRAR LA DISTANCIA PERPENDICULAR
                        vAcosA = this.GetVelocidad() * cosA;
                        vAsinA = this.GetVelocidad() * sinA;
                        XB_XA1 = XB - XA1;
                        YB_YA1 = YB - YA1;

                        tPERP = (XB_XA1 * vAcosA + YB_YA1 * vAsinA) / (vAcosA * vAcosA + vAsinA * vAsinA);
                        if (tPERP >= trecorrerRAP && tPERP <= trecorrerLEN)
                        { distanciaPERP = Math.Sqrt((XB_XA1 - vAcosA * tPERP) * (XB_XA1 - vAcosA * tPERP) + (YB_YA1 - vAsinA * tPERP) * (YB_YA1 - vAsinA * tPERP)); }
                        else
                        { distanciaPERP = -1; }
                    }

                    // Comparamos distancias y nos quedamos con la menor
                    if (distanciaPERP == -1)
                    {
                        if (distanciaI < distanciaF)
                        { distancia = distanciaI; }
                        else
                        { distancia = distanciaF; }
                    }
                    else
                    {
                        if (distanciaI < distanciaF && distanciaI < distanciaPERP)
                        { distancia = distanciaI; }
                        if (distanciaF < distanciaI && distanciaF < distanciaPERP)
                        { distancia = distanciaF; }
                        else
                        { distancia = distanciaPERP; }
                    }

                }
                else
                {
                    distanciaNORM = Math.Sqrt((OX + CV * t) * (OX + CV * t) + (OY + SV * t) * (OY + SV * t));

                    if (trecorrerRAP == trecorrerA)
                    {
                        XA = AF.GetX();
                        YA = AF.GetY();
                        XB1 = BI.GetX();
                        YB1 = BI.GetY();

                        // ENCONTRAR LA DISTANCIA PERPENDICULAR
                        vBcosB = plan.GetVelocidad() * cosB;
                        vBsinB = plan.GetVelocidad() * sinB;
                        XA_XB1 = XA - XB1;
                        YA_YB1 = YA - YB1;

                        tPERP = (XA_XB1 * vBcosB + YA_YB1 * vBsinB) / (vBcosB * vBcosB + vBsinB * vBsinB);
                        if (tPERP >= trecorrerRAP && tPERP <= trecorrerLEN)
                        { distanciaPERP = Math.Sqrt((XA_XB1 - vBcosB * tPERP) * (XA_XB1 - vBcosB * tPERP) + (YA_YB1 - vBsinB * tPERP) * (YA_YB1 - vBsinB * tPERP)); }
                        else
                        { distanciaPERP = -1; }
                    }
                    else
                    {
                        XB = BF.GetX();
                        YB = BF.GetY();
                        XA1 = AI.GetX();
                        YA1 = AI.GetY();

                        // ENCONTRAR LA DISTANCIA PERPENDICULAR
                        vAcosA = this.GetVelocidad() * cosA;
                        vAsinA = this.GetVelocidad() * sinA;
                        XB_XA1 = XB - XA1;
                        YB_YA1 = YB - YA1;

                        tPERP = (XB_XA1 * vAcosA + YB_YA1 * vAsinA) / (vAcosA * vAcosA + vAsinA * vAsinA);
                        if (tPERP >= trecorrerRAP && tPERP <= trecorrerLEN)
                        { distanciaPERP = Math.Sqrt((XB_XA1 - vAcosA * tPERP) * (XB_XA1 - vAcosA * tPERP) + (YB_YA1 - vAsinA * tPERP) * (YB_YA1 - vAsinA * tPERP)); }
                        else
                        { distanciaPERP = -1; }
                    }

                    // Comparamos distancias y nos quedamos con la menor
                    if (distanciaPERP == -1)
                    { distancia = distanciaNORM; }
                    else
                    {
                        if (distanciaNORM < distanciaPERP)
                        { distancia = distanciaNORM; }
                        else
                        { distancia = distanciaPERP; }
                    }
                }
                //MessageBox.Show(Convert.ToString(Math.Round(distancia, 2)), "Distancia:");
            }
            if (distancia < DistanciaSeguridad)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SolucionadorConflictosCambioVel(int distanciaSeg, FlightPlan plan)
        {
            double Vo = this.GetVelocidad();
            while (this.HayConflicto(distanciaSeg, plan) == true)
            {
                double velocidad = this.GetVelocidad();
                velocidad = velocidad - 0.1;
                this.SetVelocidad(velocidad);
                this.HayConflicto(distanciaSeg, plan);
                if (velocidad == 0)
                { 
                    velocidad = Vo;
                    this.SetVelocidad(velocidad);
                    break;
                }
            }
        }
        public void copiarFlightPlan(FlightPlan FP)
        {
            this.id = FP.getId();
            Position P = new Position();
            P.copiarPosicion(FP.GetInitialPosition());
            this.initialPosition = P;
            P = new Position();
            P.copiarPosicion(FP.GetCurrentPosition());
            this.currentPosition = P;
            P = new Position();
            P.copiarPosicion(FP.GetfinalPosition());
            this.finalPosition = P;
            this.velocidad = FP.GetVelocidad();
            this.combustible = FP.getComb();
        }
    }
}
