import { Table, TableBody, TableCaption, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Fetcher } from "@/features/shared/fetchers"
import PageHeader from "@/features/shared/ui/page-header"
import { WeatherForecast } from "@/features/weather/definitions"





export default async function Page() {

  const fetcher = new Fetcher<WeatherForecast>("/weatherforecast")
  const { results: forecasts, error } = await fetcher.getAll();

  if (error?.status === 500 || forecasts === undefined) {
    return (
      <div>
        <p>Error happens on backend, please try again later</p>
        <p>{error?.message}</p>
      </div>)
  }


  return (
    <div>
      <PageHeader title="Local weatherforecast"
        description="Lorem, ipsum dolor sit amet consectetur adipisicing elit. Voluptas, culpa." />
      <div>
        <Table>
          <TableCaption>Local weatherforecasts</TableCaption>
          <TableHeader className="bg-gray-100">
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
