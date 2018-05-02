class StopWatch {
    private begin: number = 0;
    private end: number = 0;

    public start(): void {
        this.begin = performance.now();
    }

    public stop(): void {
        this.end = performance.now();
    }

    public get elapsed(): number {
        return this.end - this.begin;
    }
}
