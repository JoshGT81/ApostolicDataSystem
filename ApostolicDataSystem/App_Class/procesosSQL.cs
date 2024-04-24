using ApostolicDataSystem.Models;
using hashHelper;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ApostolicDataSystem.App_Class
{
    public class procesosSQL
    {
        string sqlConnString = ConfigurationManager.AppSettings["sqlCons"];

        #region USUARIOS        
        public DataSet getListadoUsuariosActivos()
        {            
            string spName = "spr_listaUsuarios";
            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[0];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);
            return ds;
        }

        public DataSet getUsuario(string codigoUsuario)
        {            
            string spName = "spr_seleccionaUsuario";
            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[1];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            storedParms[0].Value = codigoUsuario;

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);
            return ds;
        }

        public DataSet guardarUsuario(List<parametrosEventosInfo> parametros)
        {            
            string spName = string.Empty;

            spName = "spr_guardarUsuario";

            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[parametros.Count];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            foreach (parametrosEventosInfo objetoINF in parametros)
            {
                storedParms[objetoINF.Orden].Value = objetoINF.ValorCampo;
            }

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);

            return ds;
        }
        #endregion

        #region MIEMBROS
        public DataSet getListadoMiembrosActivos()
        {            
            string spName = "spr_listaMiembros";
            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[0];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);
            return ds;
        }

        public DataSet getMiembro(string codigoMiembro)
        {            
            string spName = "spr_seleccionaMiembro";
            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[1];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            storedParms[0].Value = codigoMiembro;

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);
            return ds;
        }

        public DataSet guardaMiembro(List<parametrosEventosInfo> parametros)
        {
            string spName = string.Empty;

            spName = "spr_guardarMiembro";

            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[parametros.Count];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            foreach (parametrosEventosInfo objetoINF in parametros)
            {
                storedParms[objetoINF.Orden].Value = objetoINF.ValorCampo;
            }

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);

            return ds;
        }
        #endregion

        #region TIPOS TRANSACCIONES
        public DataSet getListadoTipoTransacciones()
        {
            string spName = "spr_listasTiposTransacciones";
            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[0];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);
            return ds;
        }

        public DataSet guardaTipoTransaccion(List<parametrosEventosInfo> parametros)
        {
            string spName = string.Empty;

            spName = "spr_guardarTipoTransaccion";

            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[parametros.Count];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            foreach (parametrosEventosInfo objetoINF in parametros)
            {
                storedParms[objetoINF.Orden].Value = objetoINF.ValorCampo;
            }

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);

            return ds;
        }
        #endregion

        #region PROCESO TRANSACCIONES
        public DataSet getCatalogosTransacciones(List<parametrosEventosInfo> parametros)
        {
            string spName = "spr_catalogosTransaccion";
            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[0];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            foreach (parametrosEventosInfo objetoINF in parametros)
            {
                storedParms[objetoINF.Orden].Value = objetoINF.ValorCampo;
            }

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);
            return ds;
        }

        public DataSet guardaTransaccion(List<parametrosEventosInfo> parametros, string tipo)
        {
            string spName = string.Empty;

            if (tipo.Equals("I"))
                spName = "spr_guardarIngreso";
            else
                spName = "spr_guardarEgreso";

            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[parametros.Count];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            foreach (parametrosEventosInfo objetoINF in parametros)
            {
                storedParms[objetoINF.Orden].Value = objetoINF.ValorCampo;
            }

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);

            return ds;
        }
        #endregion


        public DataSet getMenu(string codigoRol)
        {
            string spName = "spr_getMenu";
            DataSet ds = new DataSet();

            SqlParameter[] storedParms = new SqlParameter[1];
            storedParms = SqlHelperParameterCache.GetSpParameterSet(sqlConnString, spName);

            storedParms[0].Value = codigoRol;

            ds = SqlHelper.ExecuteDataset(sqlConnString, System.Data.CommandType.StoredProcedure, spName, storedParms);
            return ds;
        }
    }
}