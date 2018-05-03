class Calc {
    public static calculate(list: number[]): any {
        let sum = 0.0;

        for (let i = 0; i < list.length; i++) {
            sum += list[i];
        }

        const avg = sum / list.length;

        let stDevSum = 0.0;

        for (let i = 0; i < list.length; i++) {
            stDevSum += (list[i] - avg) * (list[i] - avg);
        }

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
