import { Button } from "@/components/ui/button";
import PageHeader from "@/features/shared/ui/page-header";
import Image from "next/image";

export default function Page() {

  return (
    <div>
      <PageHeader title="Tailwindcss" description="uisng tailwindcss..." />
      <section className="section">
        <h1 className="section-heading">Simple image with flex</h1>
        <article className="flex flex-col md:flex-row items-start md:items-center gap-3 shadow-md border border-slate-50 
        p-2 rounded-md overflow-hidden bg-white">
          <figure className="rounded-tr-md rounded-tl-md overflow-hidden h-[200px] w-[100%] md:w-[100%] ">
            <Image src={"/images/color.png"} alt={"simple color bg"} width={1000} height={1000} className="w-full h-full object-cover" />
          </figure>
          <div className="shadow-sm border border-slate-50 rounded-md bg-white bg-opacity-20">
            <div className="flex justify-between items-center">
              <h3 className="text-xl">Information note</h3>
              <Button className="bg-prim-100 hidden md:block">Call</Button>
            </div>
            <p className="my-2 text-sm">Lorem ipsum dolor sit, amet consectetur adipisicing elit. Asperiores, cum.</p>
          </div>
        </article>
      </section>

      <section className="section">
        <h1 className="section-heading">Containers queries</h1>
        <div className="c-container">
          <article className="info-card">
            <figure className="info-card__figure">
              <Image src={"/ecommerce-store.png"} alt="queries pictures" width={100} height={100} className="w-full h-full" />
              <figcaption className="text-gray-500 text-center md:text-left">Lorem ipsum dolor sit amet consectetur.</figcaption>
            </figure>
            <div>
              <div className="info-card__callout">
                <h2>Lorem ipsum dolor sit amet.</h2>
                <Button className="info-card__callout-btn">Callout</Button>
              </div>
              <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Modi assumenda magni eligendi, hic excepturi mollitia.</p>
            </div>
          </article>
        </div>
      </section>
    </div>
  )
}