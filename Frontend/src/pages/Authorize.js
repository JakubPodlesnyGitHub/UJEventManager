import React from "react";
import SignIn from "../input/SignIn";
import FormWindow from "../input/FormWindow";
import SignUp from "../input/SignUp";

export default function Auth() {
  return <>{FormWindow(Array.from([<SignIn />, <SignUp />]))}</>;
}
