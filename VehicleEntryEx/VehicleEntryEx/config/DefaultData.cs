using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace VehicleEntryEx
{
    public class DefaultData
    {
        /// <summary>
        /// 默认打印模板
        /// </summary>
        public static string SalePrintModelStr = @"! 0 200 200 540 1
ENCODING GB18030
PW 559
TONE 0
SPEED 2
ON-FEED IGNORE
NO-PACE
BAR-SENSE
BT 0 0 0
B 128 1 0 52 20 20 batchID
TEXT GBUNSG24.CPF 0 300 35 role
T 7 0 10 90 ---------------------------------------
TEXT GBUNSG24.CPF 0 20 115 登记日期:
T 7 0 130 115 registerDate
TEXT GBUNSG24.CPF 0 20 139 批次号:
T 7 0 130 139 batchID
TEXT GBUNSG24.CPF 0 20 163 门店号:
TEXT GBUNSG24.CPF 0 130 163 shopID
TEXT GBUNSG24.CPF 0 270 163 经营户:
TEXT GBUNSG24.CPF 0 360 163 owner
T 7 0 10 183 ---------------------------------------
TEXT GBUNSG24.CPF 0 20 203 车船号:
TEXT GBUNSG24.CPF 0 130 203 trafficID
TEXT GBUNSG24.CPF 0 20 227 品种:
TEXT GBUNSG24.CPF 0 130 227 type
TEXT GBUNSG24.CPF 0 20 251 品牌:
TEXT GBUNSG24.CPF 0 130 251 brand
TEXT GBUNSG24.CPF 0 270 251 产地:
TEXT GBUNSG24.CPF 0 360 251 origin
TEXT GBUNSG24.CPF 0 20 275 整重:
T 7 0 130 275 wholeWeight
TEXT GBUNSG24.CPF 0 270 275 毛重:
TEXT GBUNSG24.CPF 0 360 275 grossWeight
TEXT GBUNSG24.CPF 0 20 299 数量:
TEXT GBUNSG24.CPF 0 130 299 quantity unit
T 7 0 10 319 ---------------------------------------
TEXT GBUNSG24.CPF 0 20 339 押金:
T 7 0 130 339 deposit
TEXT GBUNSG24.CPF 0 270 339 应收费:
T 7 0 360 339 fees
TEXT GBUNSG24.CPF 0 20 363 实收费:
T 7 0 130 363 charges
T 7 0 10 383 ---------------------------------------
TEXT GBUNSG24.CPF 0 20 403 □结算
TEXT GBUNSG24.CPF 0 20 427 备注:
PRINT
";
        public static string KeeperPrintModelStr = @"! 0 200 200 540 1
ENCODING GB18030
PW 559
TONE 0
SPEED 2
ON-FEED IGNORE
NO-PACE
BAR-SENSE
BT 0 0 0
B 128 1 0 52 20 20 batchID
TEXT GBUNSG24.CPF 0 300 35 role
T 7 0 10 90 ---------------------------------------
TEXT GBUNSG24.CPF 0 20 115 登记日期:
T 7 0 130 115 registerDate
TEXT GBUNSG24.CPF 0 20 139 批次号:
T 7 0 130 139 batchID
TEXT GBUNSG24.CPF 0 20 163 门店号:
TEXT GBUNSG24.CPF 0 130 163 shopID
TEXT GBUNSG24.CPF 0 270 163 经营户:
TEXT GBUNSG24.CPF 0 360 163 owner
T 7 0 10 183 ---------------------------------------
TEXT GBUNSG24.CPF 0 20 203 车船号:
TEXT GBUNSG24.CPF 0 130 203 trafficID
TEXT GBUNSG24.CPF 0 20 227 品种:
TEXT GBUNSG24.CPF 0 130 227 type
TEXT GBUNSG24.CPF 0 20 251 品牌:
TEXT GBUNSG24.CPF 0 130 251 brand
TEXT GBUNSG24.CPF 0 270 251 产地:
TEXT GBUNSG24.CPF 0 360 251 origin
TEXT GBUNSG24.CPF 0 20 275 整重:
T 7 0 130 275 wholeWeight
TEXT GBUNSG24.CPF 0 270 275 毛重:
TEXT GBUNSG24.CPF 0 360 275 grossWeight
TEXT GBUNSG24.CPF 0 20 299 数量:
TEXT GBUNSG24.CPF 0 130 299 quantity unit
T 7 0 10 319 ---------------------------------------
TEXT GBUNSG24.CPF 0 20 339 押金:
T 7 0 130 339 deposit
PRINT
";
    }
}
