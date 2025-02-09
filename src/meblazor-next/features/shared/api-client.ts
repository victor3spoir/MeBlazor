import { EnvVars } from "@/env";
import axios from "axios";

export const apiClient = axios.create({ baseURL: EnvVars.BACKEND_ENDPOINT })