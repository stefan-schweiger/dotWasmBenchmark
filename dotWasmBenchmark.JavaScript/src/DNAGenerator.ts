const IM = 139968;
const IA = 3877;
const IC = 29573;

class Rand {
    public static random(): number {
        Rand.seed = (Rand.seed * IA + IC) % IM;
        return Rand.seed;
    }

    private static seed = 42;
}

// tslint:disable-next-line:max-classes-per-file
class Frequency {
    public c: string;
    public p: number;

    constructor(c: string, p: number) {
        this.c = c;
        this.p = Math.trunc(p * IM);
    }
}

// tslint:disable-next-line:max-classes-per-file
class DNAGenerator {
    private static frequencies = [
        new Frequency("a", 0.3029549426680),
        new Frequency("c", 0.1979883004921),
        new Frequency("g", 0.1975473066391),
        new Frequency("t", 0.3015094502008),
    ];

    // tslint:disable-next-line:member-ordering
    public static init() {
        DNAGenerator.makeCumulative(DNAGenerator.frequencies);
    }

    // tslint:disable-next-line:member-ordering
    public static generate(n: number, length: number) {
        const res = [];

        for (let i = 0; i < n; i++) {
            let str = "";

            for (let j = 0; j < length; j++) {
                str += this.GetRandomCode();
            }

            res[i] = str;
        }

        return res;
    }

    private static makeCumulative(a: Frequency[]): void {
        let cp = 0;
        // tslint:disable-next-line:prefer-for-of
        for (let i = 0; i < a.length; i++) {
            cp += a[i].p;
            a[i].p = cp;
        }
    }

    private static GetRandomCode() {
        const r = Rand.random();
        const frequencies = this.frequencies;

        // tslint:disable-next-line:prefer-for-of
        for (let i = 0; i < frequencies.length; i++) {
            if (r < frequencies[i].p) {
                return frequencies[i].c;
            }
        }

        return frequencies[frequencies.length - 1].c;
    }
}

DNAGenerator.init();
