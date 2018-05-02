class Calc {
    public static calculate(list: number[]): any {
        const sum = list.reduce((prev, curr) => prev + curr, 0);
        const avg = sum / list.length;
        const stDevSum = list.reduce((prev, curr) => (curr - avg) * (curr - avg) + prev, 0);
        const stDev = Math.sqrt(stDevSum / list.length);

        return {
            q1: list[list.length / 4],
            median: list[list.length / 2],
            q3: list[list.length / 4 * 3],
            avg: avg,
            stDev: stDev
        };
    }
}
