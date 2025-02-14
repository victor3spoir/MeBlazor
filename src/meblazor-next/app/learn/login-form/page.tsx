"use client"

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { KeyRoundIcon, UserCircle2Icon } from "lucide-react";
import { FormEvent } from "react";

export default function Page() {
  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()
    const loginForm = document.forms[0]

    loginForm.reset()


  }
  return (
    <div className="h-full flex items-center justify-center">

      <form name="login-form" onSubmit={handleSubmit}
        className="max-w-[500px] px-2 py-3 rounded-lg shadow-md flex flex-col justify-center items-center">
        <h2 className="text-3xl my-3">Log to your account</h2>
        <div className="flex items-center gap-3">
          <label htmlFor="username"><UserCircle2Icon /></label>
          <Input type="username" name="username" id="username" required autoComplete="given-name"
            className="flex-1" minLength={3} />
        </div>
        <div className="flex items-center gap-3">
          <label htmlFor="current-password"><KeyRoundIcon /></label>
          <Input type="password" name="password" id="current-password" required autoComplete="current-password"
            className="flex-1" />
        </div>
        <div className="flex items-center">
          <Button variant={"secondary"} className="flex-1 bg-green-500">Login</Button>
        </div>
      </form>
    </div>
  )
}