import React from 'react';

const StrongPoint = () => {
    return (
        <div>
            <div className="relative justify-center flex items-center">
                <div className=""><img alt="image de decoration" className="w-40 mr-4" src="/img/decoration/decoration_right.jpg"></img></div>
                <h2 className="text_nav leading-7 text.black sm:truncate sm:text-3xl ">Notre point fort</h2>
                <div className=""><img alt="image de decoration" className="w-40 ml-4" src="/img/decoration/decoration_left.jpg"/></div>
            </div>
            <div className="mt-5">
                <div className="mx-auto max-w-7xl px-6 lg:px-8">
                    <dl className="grid grid-cols-1 gap-x-8 gap-y-16 text-center lg:grid-cols-3">
                        <div className="mx-auto flex max-w-xs flex-col gap-y-4 mt-2">
                            <dt className="text-base leading-7 text-gray-600">Quality</dt>
                            <p>Un matériau est considéré comme recyclable lorsqu'il peut être collecté, transformé et réutilisé pour la production de nouveaux matériaux </p>
                            <dd className="order-first text-3xl font-semibold tracking-tight text-gray-900 sm:text-5xl flex justify-center">
                                <img src="/img/icons/icons_recycler100.png" className="logo2"></img>
                            </dd>
                        </div>
                        <div className="mx-auto flex max-w-xs flex-col gap-y-4 ">
                            <dt className="text-base leading-7 text-gray-600">Quality</dt>
                            <p>Un matériau est considéré comme recyclable lorsqu'il peut être collecté, transformé et réutilisé pour la production de  </p>
                            <dd className="order-first text-3xl font-semibold tracking-tight text-gray-900 sm:text-5xl flex justify-center">
                                <img src="/img/icons/icons_recession100.png" className="logo3"></img>
                            </dd>
                        </div>
                        <div className="mx-auto flex max-w-xs flex-col gap-y-4">
                            <dt className="text-base leading-7 text-gray-600">Quality</dt>
                            <p>Un matériau est considéré comme recyclable lorsqu'il peut être collecté, transformé et réutilisé pour la production de nouveaux </p>
                            <dd className="order-first text-3xl font-semibold tracking-tight text-gray-900 sm:text-5xl flex justify-center">
                                <img src="/img/icons/icons_best_seller100.png" className="logo1"></img>
                            </dd>
                        </div>

                    </dl>
                </div>
            </div>
        </div>
    );
};

export default StrongPoint;