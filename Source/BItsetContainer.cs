﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsetsNET
{
    class BitsetContainer : Container
    {
        protected const int MAX_CAPACITY = 1 << 64;

        int cardinality;
        long[] bitmap;

        public BitsetContainer()
        {
            this.cardinality = 0;
            this.bitmap = new long[MAX_CAPACITY / 64];
        }


        public override Container add(ushort x)
        {
            uint y = Utility.toIntUnsigned(x);
            long prevVal = bitmap[x / 64];
            long newVal = prevVal | (1L << x);
            bitmap[x / 64] = newVal;
            if (prevVal != newVal) ++cardinality;
            return this;
        }

        public void loadData(ArrayContainer arrayContainer)
        {
            this.cardinality = arrayContainer.cardinality;
            for (int k = 0; k < arrayContainer.cardinality; ++k)
            {
                ushort x = arrayContainer.content[k];
                bitmap[Utility.toIntUnsigned(x) / 64] |= (1L << x);
            }
        }

        public override Container and(BitsetContainer x)
        {
            throw new NotImplementedException();
        }

        public override Container and(ArrayContainer x)
        {
            throw new NotImplementedException();
            ArrayContainer answer = new ArrayContainer(x.content.Length);
            int c = x.cardinality;
            for (int i=0; i<c; i++)
            {
                ushort v = x.content[i];
                if (this.contains(v))
                    answer.content[answer.cardinality++] = v;
            }
            return answer;
        }

        public override Container clone()
        {
            throw new NotImplementedException();
        }

        public override bool contains(ushort x)
        {
            return (bitmap[x / 64] & (1L << x)) != 0;
        }

        public override void fillLeastSignificant16bits(int[] x, int i, int mask)
        {
            throw new NotImplementedException();
        }

        public override int getCardinality()
        {
            throw new NotImplementedException();
        }

        public override Container iand(BitsetContainer x)
        {
            throw new NotImplementedException();
        }

        public override Container iand(ArrayContainer x)
        {
            throw new NotImplementedException();
        }

        public override bool intersects(BitsetContainer x)
        {
            throw new NotImplementedException();
        }

        public override bool intersects(ArrayContainer x)
        {
            throw new NotImplementedException();
        }

        public override Container ior(BitsetContainer x)
        {
            throw new NotImplementedException();
        }

        public override Container ior(ArrayContainer x)
        {
            throw new NotImplementedException();
        }

        public override Container or(BitsetContainer x)
        {
            throw new NotImplementedException();
        }

        public override Container or(ArrayContainer x)
        {
            throw new NotImplementedException();
        }

        public override Container remove(ushort x)
        {
            throw new NotImplementedException();
        }

        public override short select(int j)
        {
            throw new NotImplementedException();
        }

    }
}