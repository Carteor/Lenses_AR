/* 
 * PROJECT: NyARToolkitCS
 * --------------------------------------------------------------------------------
 *
 * The NyARToolkitCS is C# edition NyARToolKit class library.
 * Copyright (C)2008-2012 Ryo Iizuka
 *
 * This work is based on the ARToolKit developed by
 *   Hirokazu Kato
 *   Mark Billinghurst
 *   HITLab, University of Washington, Seattle
 * http://www.hitl.washington.edu/artoolkit/
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as publishe
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * For further information please contact.
 *	http://nyatla.jp/nyatoolkit/
 *	<airmail(at)ebony.plala.or.jp> or <nyatla(at)nyatla.jp>
 * 
 */
namespace jp.nyatla.nyartoolkit.cs.markersystem.utils
{




    public class MarkerInfoNyId : TMarkerData
    {
        /** MK_NyIdの情報。 反応するidの開始レンジ*/
        public readonly long nyid_range_s;
        /** MK_NyIdの情報。 反応するidの終了レンジ*/
        public readonly long nyid_range_e;
        /** MK_NyIdの情報。 実際のid値*/
        public long nyid;
        public int dir;
        /**
         * コンストラクタです。初期値から、Idマーカのインスタンスを生成します。
         * @param i_range_s
         * @param i_range_e
         * @param i_patt_size
         * @
         */
        public MarkerInfoNyId(long i_nyid_range_s, long i_nyid_range_e, double i_patt_size):base()
        {
            this.marker_offset.setSquare(i_patt_size);
            this.nyid_range_s = i_nyid_range_s;
            this.nyid_range_e = i_nyid_range_e;
            return;
        }
    }
}