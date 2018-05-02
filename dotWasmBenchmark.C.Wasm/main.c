#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>

int Partition(double list[], int left, int right)
{
    int start = left;
    double pivot = list[start];
    left++;
    right--;

    while (1 == 1)
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

        double temp = list[left];
        list[left] = list[right];
        list[right] = temp;
    }
}

void QuickSort(double list[], int left, int right)
{
    if (left < right)
    {
        int pivotIdx = Partition(list, left, right);
        QuickSort(list, left, pivotIdx - 1);
        QuickSort(list, pivotIdx, right);
    }
}

int main()
{
    const int N = 25000;
    double randoms[N];

    clock_t t;

    t = clock();

    for (int i = 0; i < N; i++)
    {
        randoms[i] = (double)rand()/RAND_MAX;
    }

    t = clock() - t;

    printf("Generate:  %.2fms\n", (double)t / CLOCKS_PER_SEC * 1000);

    t = clock();
    QuickSort(randoms, 0, N);
    t = clock() - t;

    printf("Sort:      %.2fms\n", (double)t / CLOCKS_PER_SEC * 1000);

    t = clock();
    double sum = 0.0;
    double avg = 0.0;

    for (int i = 0; i < N; i++) {
        sum += randoms[i];
    }

    avg = sum / N;

    double stDevSum = 0.0;

    for (int i = 0; i < N; i++) {
        stDevSum += (randoms[i] - avg) * (randoms[i] - avg);
    }

    double stDev = sqrt(stDevSum / N);
    t = clock() - t;

    printf("Calculate: %.2fms\n", (double)t / CLOCKS_PER_SEC * 1000);

    printf("----------------------------------------------\n");

    printf("Q1     %.5f\n", randoms[N/4]);
    printf("Median %.5f\n", randoms[N/2]);
    printf("Q3     %.5f\n", randoms[(N/4)*3]);
    printf("Avg.   %.5f\n", avg);
    printf("StDev. %.5f\n", stDev);

    return 0;
}