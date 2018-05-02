class Sequencer {
    public static sequenceMatch(seq: string[]): number[] {
        const n = seq.length;
        const list: number[] = [];

        //const regex = /tta|ttg|ctt|ctc|cta|ctg/g;

        for (let i = 0; i < n; i++) {
            //const matches = seq[i].match(regex) || [];
            list[i] = 1.0;

            var gen = seq[i];
            list[i] = 1.0;

            for (let j = 0; j < gen.length - 3; j++) {
                var s = gen.substr(j, 3);

                switch (s)
                {
                    case "tta":
                        list[i] *= 1.2345;
                        break;
                    case "ttg":
                        list[i] *= 0.9485;
                        break;
                    case "ctt":
                        list[i] *= 1.9323;
                        break;
                    case "ctc":
                        list[i] *= 1.0033;
                        break;
                    case "cta":
                        list[i] *= 0.9999;
                        break;
                    case "ctg":
                        list[i] *= 0.8242;
                        break;
                }
            }

            /*for (const match of matches) {
                switch (match)
                {
                    case "tta":
                        list[i] *= 1.2345;
                        break;
                    case "ttg":
                        list[i] *= 0.9485;
                        break;
                    case "ctt":
                        list[i] *= 1.9323;
                        break;
                    case "ctc":
                        list[i] *= 1.0033;
                        break;
                    case "cta":
                        list[i] *= 0.9999;
                        break;
                    case "ctg":
                        list[i] *= 0.8242;
                        break;
                }
            }*/
        }

        return list;
    }
}