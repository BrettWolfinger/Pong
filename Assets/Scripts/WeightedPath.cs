using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedPath
{
    public static string SolveProblem()
    {
        string[] input = new string[]{"4", "A", "B", "C", "D", "B|C|11"};

        //safety check that input has something. Depending on constraints/safety protocol there could be more input checking cases.
        if(input.Length == 0) return "-1";

        int num_nodes = Int32.Parse(input[0]);

        //there are no edges so cannot run the algorithm
        if(input.Length == num_nodes+1) return "-1";

        //initialize adjacency matrix using number of nodes
        int[,] a_matrix = new int[num_nodes,num_nodes];

        //for each edge in the input string, add weights to adjacency matrix
        for(int i = num_nodes+1; i < input.Length; i++)
        {
            string[] edge = input[i].Split('|');
            //get indices of the nodes and adjust by one to align them with indices in adjacency matrix
            int start = Array.IndexOf(input, edge[0]) - 1;
            int end = Array.IndexOf(input, edge[1]) - 1;

            //add the weight to the adjacency matrix
            a_matrix[start,end] = Int32.Parse(edge[2]);
        }

        //debug to print adjacency matrix
        // Print2DArray(a_matrix);

        //all distances are unknown to start so we initialize to max value
        int[] dist = new int[num_nodes];
        Array.Fill(dist, int.MaxValue);

        //No nodes have a path yet, use -2 to signify there is no previous node
        int[] prev = new int[num_nodes];
        Array.Fill(prev, -2);

        //None of nodes have been explored
        bool[] explored = new bool[num_nodes];
        Array.Fill(explored, false);

        int least_value_index = -1;

        //source node is always the first node in this problem, and it has no parent so use special escape of -1
        dist[0] = 0;
        prev[0] = -1;

        //the algorithm will execute as many times as there are nodes to explore.
        for(int node = 0; node < num_nodes; node++)
        {
            int least_value = int.MaxValue;
            //determine least valued unexplored vertex
            for(int i = 0; i < dist.Length; i++)
            {
                //must be unexplored
                if(!explored[i])
                {
                    if(dist[i] < least_value)
                    {
                        least_value = dist[i];
                        least_value_index = i;
                    }
                }
            }

            //set value to explored
            explored[least_value_index] = true;

            //Update estimates
            for(int w = 0; w < num_nodes; w++)
            {
                //check that an edge exists between the two vertices, and if the new distance is lower, update
                if(a_matrix[least_value_index, w] != 0
                    && dist[least_value_index] + a_matrix[least_value_index, w] < dist[w])
                {
                    dist[w] = dist[least_value_index] + a_matrix[least_value_index, w];
                    prev[w] = least_value_index;
                }
            }
        }

        // debug prints for the distance and parent matrix
        // foreach(int val in dist)
        // {
        //     Console.Write(val + "\t");
        // }
        // Console.WriteLine();

        // foreach(int val in prev)
        // {
        //     Console.Write(val + "\t");
        // }
        // Console.WriteLine();

        //final node was unable to link, there is no connection, return early
        if(dist[num_nodes-1] == int.MaxValue)
        {
            return "-1";
        }

        //track path backwards through lineage to build output string
        string output = "";
        int parent = prev[num_nodes-1];
        output += input[num_nodes];
        while(parent != -1)
        {
            parent = prev[parent];
            output = input[parent+2] + "-" + output;
        }

        //check output
        //Console.WriteLine(output);
        return output;

    }   

    public static void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }

}
