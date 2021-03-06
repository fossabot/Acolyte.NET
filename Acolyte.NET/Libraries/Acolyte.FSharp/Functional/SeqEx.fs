﻿/// <summary>
/// Contains additional methods to work with <see cref="Microsoft.FSharp.Collections.seq{T}" />.
/// </summary>
module Acolyte.Functional.SeqEx


let skipSafe (num: int32) (source: seq<'a>) : seq<'a> =
    Throw.checkIfNull source "source"

    seq {
        use e = source.GetEnumerator()
        let idx = ref 0
        let loop = ref true
        while !idx < num && !loop do
            if not(e.MoveNext()) then
                loop := false
            idx := !idx + 1

        while e.MoveNext() do
            yield e.Current 
    }
