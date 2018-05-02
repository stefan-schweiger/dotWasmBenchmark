class Sort {
    static quickSort(list: number[]) {
        this.quickSortInternal(list, 0, list.length);
    }

    static quickSortInternal(list: number[], left: number, right: number) {
        if (list == null || list.length <= 1)
            return;

        if (left < right) {
            const pivotIdx = this.partition(list, left, right);
            this.quickSortInternal(list, left, pivotIdx - 1);
            this.quickSortInternal(list, pivotIdx, right);
        }
    }

    static partition(list: number[], left: number, right: number): number {
        const start = left;
        const pivot = list[start];

        left++;
        right--;

        while (true)
        {
            while (left <= right && list[left] <= pivot)
                left++;

            while (left <= right && list[right] > pivot)
                right--;

            if (left > right)
            {
                list[start] = list[left - 1];
                list[left - 1] = pivot;

                return left;
            }


            const temp = list[left];
            list[left] = list[right];
            list[right] = temp;

        }
    }
}
