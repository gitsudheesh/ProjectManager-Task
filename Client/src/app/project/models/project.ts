import { Task } from "../../task/models/task";

export interface Project {
    Project_ID?: number,
    Project_Name: string,
    Start_Date?: Date,
    End_Date?: Date,
    Priority: number,
    Manager_ID?:number,
    Tasks?: Task[]
}