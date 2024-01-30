import React from 'react';

const features = [
  { name: 'Origin', description: 'Designed by Good Goods, Inc.' },
  { name: 'Material', description: 'Solid walnut base with rare earth magnets and powder coated steel card cover' },
]

export default function Contact() {
  return (
      <div className="bg-white shadow-xl">
        <div className="relative justify-center flex items-center">
          <div className=""><img alt="image de decoration" className="w-40 mr-4" src="/img/decoration/decoration_right.jpg"></img></div>
          <h2 className="text_nav leading-7 text.black sm:truncate sm:text-3xl ">Contact</h2>
          <div className=""><img alt="image de decoration" className="w-40 ml-4" src="/img/decoration/decoration_left.jpg"/></div>
        </div>
        <div className="mx-auto grid max-w-5xl grid-cols-1 items-center  gap-x-2 gap-y-16 px-4 py-2 sm:px-6 sm:py-3 lg:max-w-[1500px] lg:grid-cols-2 lg:px-8">
          <div className="rounded-md max-w-2xl flex justify-center m-7 bg-white overflow-hidden md:max-w-7xl">
          <div className="md:shrink-0 flex align-bottom rounded-md">
            <video className="h-[350px] max-w rounded-[50px]  mx-auto " loop autoPlay muted>
              <source src="/video/production.mp4" type="video/mp4"/>
              Votre navigateur ne prend pas en charge la vidéo.
            </video >
          </div>
          </div>
          <div>
            <form action="#" method="POST" className="">
              <div className="grid grid-cols-1 gap-x-8 gap-y-6 sm:grid-cols-2">
                <div>
                  <label htmlFor="first-name" className="block text-sm font-semibold text-gray-900">
                    First name
                  </label>
                  <div className="mt-2.5">
                    <input
                        type="text"
                        name="first-name"
                        id="first-name"
                        autoComplete="given-name"
                        className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>
                <div>
                  <label htmlFor="last-name" className="block text-sm font-semibold leading-6 text-gray-900">
                    Last name
                  </label>
                  <div className="mt-2.5">
                    <input
                        type="text"
                        name="last-name"
                        id="last-name"
                        autoComplete="family-name"
                        className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>
                <div className="sm:col-span-2">
                  <label htmlFor="message" className="block text-sm font-semibold leading-6 text-gray-900">
                    Message
                  </label>
                  <div className="mt-2.5">
              <textarea
                  name="message"
                  id="message"
                  rows={4}
                  className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                  defaultValue={''}
              />
                  </div>
                </div>

              </div>
              <div className="mt-10 flex justify-center">
                <button
                    type="submit"
                    className="block w-50 rounded-md bg-indigo-600 px-3.5 py-2.5 text-center text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                >
                  Confirme
                </button>
              </div>
            </form>

          </div>

        </div>
      </div>
  )
}
