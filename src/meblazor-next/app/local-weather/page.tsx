import { Table, TableBody, TableCaption, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { apiClient } from "@/features/shared/api-client"
import PageHeader from "@/features/shared/ui/page-header"
import { WeatherForecast } from "@/features/weather/definitions"





export default async function Page() {

  const forecasts = (await apiClient.get("/weatherforecast")).data as WeatherForecast[]

  return (
    <div>
      <h2></h2>
      <PageHeader title="Local weatherforecast"
        description="Lorem, ipsum dolor sit amet consectetur adipisicing elit. Voluptas, culpa." />
      <div>
        <Table>
          <TableCaption>Local weatherforecasts</TableCaption>
          <TableHeader>
            <TableRow>
              <TableHead>Date</TableHead>
              <TableHead>Temp. C</TableHead>
              <TableHead>Temp. F</TableHead>
              <TableHead>Summary</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {forecasts.map(forecast => (
              <TableRow key={forecast.id}>
                <TableCell>{forecast.date}</TableCell>
                <TableCell>{forecast.temperatureC}</TableCell>
                <TableCell>{forecast.temperatureF}</TableCell>
                <TableCell>{forecast.summary}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    </div>
  )
}